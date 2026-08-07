#!/usr/bin/env python3
"""
仅处理 Designer.cs 文件中属性赋值的字符串。
用法: python localize_designer.py [--dry-run]
"""

import re
import sys
import shutil
from pathlib import Path

SRC_DIR = Path(__file__).parent / "src"
BACKUP_DIR = Path(__file__).parent / "srcold"
DRY_RUN = "--dry-run" in sys.argv

# 需要跳过的属性（内部标识符，非用户可见文本）
SKIP_PROPERTIES = ['Name', 'Size', 'Location', 'TabIndex', 'Dock', 'Anchor', 'ForeColor', 'BackColor']

# 构造函数调用中不应包裹的字符串（字体名、图标路径、尺寸等）
SKIP_CONSTRUCTORS = [
    'new Font(',
    'new Icon(',
    'new Size(',
    'new Point(',
    'new Padding(',
    'new System.Drawing',
    'new System.Windows',
]

# 不应处理的文件（自动生成的资源文件）
SKIP_FILES = ['Resources.Designer.cs']


def should_skip_line(line: str) -> bool:
    """跳过不应处理的行"""
    stripped = line.strip()
    # 跳过注释行
    if stripped.startswith('//') or stripped.startswith('///'):
        return True
    # 跳过构造函数调用
    for kw in SKIP_CONSTRUCTORS:
        if kw in line:
            return True
    return False


def wrap_array_strings(line: str) -> tuple[str, int]:
    """包裹数组初始化器中的字符串，如 { "a", "b" } -> { Localize("a"), Localize("b") }"""
    count = 0

    def repl(m):
        nonlocal count
        s = m.group(1)
        # 跳过空串和已包裹的
        if s == '' or 'Localize(' in line[max(0, m.start()-20):m.start()]:
            return m.group(0)
        # 跳过文件过滤器
        if '|' in s and '.' in s:
            return m.group(0)
        # 跳过属性赋值 (= "..." 的右侧，由 PROP_RE 已处理)
        before = line[:m.start()].rstrip()
        if before.endswith('='):
            return m.group(0)
        count += 1
        return f'Localize("{s}")'

    # 匹配数组内的 "..." 字符串（在 { ... } 之间）
    new_line = re.sub(r'(?<![$\w])"((?:[^"\\]|\\.)*)"', repl, line)
    return new_line, count


def wrap_property_strings(line: str) -> tuple[str, int]:
    """包裹属性赋值 = "..." 中的字符串"""
    count = 0

    def repl(m):
        nonlocal count
        prop = m.group(1)
        s = m.group(2)
        # 跳过空串
        if s == '':
            return m.group(0)
        # 跳过内部标识符属性（.Name, .Size 等）
        prop_name = prop.strip().lstrip('.').split('=')[0].strip()
        if prop_name in SKIP_PROPERTIES:
            return m.group(0)
        # 跳过已包裹的
        if 'Localize(' in line[max(0, m.start()-20):m.start()]:
            return m.group(0)
        # 跳过文件过滤器
        if '|' in s and '.' in s:
            return m.group(0)
        count += 1
        return f'{prop} = Localize("{s}")'

    # 匹配 .Property = "value" 模式
    new_line = re.sub(r'(\.\w+\s*=\s*)"((?:[^"\\]|\\.)*)"', repl, line)
    return new_line, count


def process_file(filepath: Path) -> int:
    # 跳过自动生成的资源文件
    if filepath.name in SKIP_FILES:
        return 0

    with open(filepath, 'r', encoding='utf-8') as f:
        lines = f.readlines()

    total = 0
    new_lines = []

    for line in lines:
        if should_skip_line(line):
            new_lines.append(line)
            continue

        # 先处理属性赋值，再处理数组字面量
        line, c1 = wrap_property_strings(line)
        line, c2 = wrap_array_strings(line)
        total += c1 + c2
        new_lines.append(line)

    if total > 0 and not DRY_RUN:
        with open(filepath, 'w', encoding='utf-8') as f:
            f.writelines(new_lines)

    return total


def main():
    if not SRC_DIR.exists():
        print(f"[错误] 源目录不存在: {SRC_DIR}")
        sys.exit(1)

    if not DRY_RUN:
        if BACKUP_DIR.exists():
            shutil.rmtree(BACKUP_DIR)
        print(f"[备份] {SRC_DIR} -> {BACKUP_DIR}")
        shutil.copytree(SRC_DIR, BACKUP_DIR)
    else:
        print("[预览模式]\n")

    designer_files = sorted(SRC_DIR.rglob("*Designer.cs"))
    print(f"找到 {len(designer_files)} 个 Designer.cs 文件\n")

    total = 0
    for fp in designer_files:
        rel = fp.relative_to(SRC_DIR)
        try:
            n = process_file(fp)
            if n > 0:
                tag = "[预览]" if DRY_RUN else "[已改]"
                print(f"  {tag} {rel}: {n} 处")
                total += n
        except Exception as e:
            print(f"  [错误] {rel}: {e}")

    print(f"\n总计: {total} 处替换")
    if DRY_RUN:
        print("去除 --dry-run 以实际修改")


if __name__ == "__main__":
    main()
