namespace Anjian.App;

internal static class ImageResourceUiSmokeTestRunner
{
    public static int Run()
    {
        var root = Path.Combine(Path.GetTempPath(), "KeyFlowStudio-ImageResourceSmoke", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        var scriptPath = Path.Combine(root, "smoke.lua");
        File.WriteAllText(scriptPath, string.Empty);

        try
        {
            ApplicationConfiguration.Initialize();
            using var form = new ImageResourceManagerForm(scriptPath, string.Empty);
            form.CreateControl();
            form.PerformLayout();
            foreach (Control control in form.Controls)
                control.PerformLayout();
            return 0;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
            return 1;
        }
        finally
        {
            try
            {
                Directory.Delete(root, recursive: true);
            }
            catch
            {
                // Temporary cleanup is best-effort after reporting the UI smoke result.
            }
        }
    }
}
