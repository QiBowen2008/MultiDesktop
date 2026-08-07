using I18N.DotNet;
using System.Data;
using System.Linq;
using static I18N.DotNet.Localizer;

namespace MultiDesktop
{
    public partial class frmSet : Form
    {

        public frmSet()
        {
            InitializeComponent();
        }

        private void drpColorMode_SelectedValueChanged(object sender, AntdUI.ObjectNEventArgs e)
        {
            drpColorMode.Text = drpColorMode.SelectedValue?.ToString();
            AppSettingsManager.ColorMode.TryGetValue(drpColorMode.Text, out SystemColorMode systemColorMode);
            Application.SetColorMode(systemColorMode);
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            AppSettingsManager.AppSettings.Rows.Find("Color")?["Value"] = AppSettingsManager.GetColorNum(drpColorMode.Text);
            AppSettingsManager.AppSettings.Rows.Find("ExitMode")?["Value"] = AppSettingsManager.GetExitModeNum(drpExitMode.Text);
            AppSettingsManager.AppSettings.WriteXml(AppPaths.AppSettings, XmlWriteMode.WriteSchema);
            Close();
        }

        private void frmSet_Load(object sender, EventArgs e)
        {
            // I18N 国际化
            this.Text = GlobalLocalizer.Localize(this.Text);
            label1.Text = GlobalLocalizer.Localize(label1.Text);
            label2.Text = GlobalLocalizer.Localize(label2.Text);
            label3.Text = GlobalLocalizer.Localize(label3.Text);
            btnSaveSettings.Text = GlobalLocalizer.Localize(btnSaveSettings.Text);
            btnClose.Text = GlobalLocalizer.Localize(btnClose.Text);
            button1.Text = GlobalLocalizer.Localize(button1.Text);

            drpColorMode.Text =AppSettingsManager.GetColor(Convert.ToInt16(AppSettingsManager.AppSettings.Rows.Find("Color")?["Value"]));
            drpExitMode.Text = AppSettingsManager.GetExitMode(Convert.ToInt16(AppSettingsManager.AppSettings.Rows.Find("ExitMode")?["Value"]));
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btnInstallSkills_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 安装 SKILL.md 到 OpenClaw/WorkBuddy skill 目录
                var skillDir = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    ".workbuddy", "skills", "MultiDesktop");
                Directory.CreateDirectory(skillDir);

                var sourceSkillMd = Path.Combine(AppContext.BaseDirectory, "SKILL.md");
                var destSkillMd = Path.Combine(skillDir, "SKILL.md");

                if (!File.Exists(sourceSkillMd))
                {
                    MessageBox.Show($"未找到 SKILL.md 文件:\n{sourceSkillMd}", "安装失败",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                File.Copy(sourceSkillMd, destSkillMd, overwrite: true);

                // 2. 将 exe 所在目录添加到用户 PATH
                var exeDir = AppContext.BaseDirectory.TrimEnd('\\');
                var currentPath = Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User) ?? "";

                var pathAlreadySet = currentPath
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .Any(p => string.Equals(p.Trim().TrimEnd('\\'), exeDir, StringComparison.OrdinalIgnoreCase));

                if (!pathAlreadySet)
                {
                    var newPath = currentPath.TrimEnd(';') + ";" + exeDir;
                    Environment.SetEnvironmentVariable("Path", newPath, EnvironmentVariableTarget.User);
                }

                var pathMsg = pathAlreadySet ? "PATH 已存在，无需重复添加" : "PATH 已添加";
                MessageBox.Show(
                    $"Skills 安装成功！\n\n" +
                    $"Skill 目录: {skillDir}\n" +
                    $"{pathMsg}: {exeDir}",
                    "安装成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"安装失败: {ex.Message}", "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void drpExitMode_SelectedValueChanged(object sender, AntdUI.ObjectNEventArgs e)
        {
            drpExitMode.Text = drpExitMode.SelectedValue?.ToString();
        }
    }
}
