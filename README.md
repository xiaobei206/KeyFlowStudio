# Mouscript Lite

Mouscript Lite 1.0.0 是一款面向 Windows 10/11 x64 的轻量桌面自动化工具，使用 WinForms、.NET 10 与 Lua 5.4。

## 下载

- Mouscript Lite 1.0.0 Release：https://github.com/xiaobei206/anjian/releases/tag/v1.0.0
- Windows x64 ZIP：MouscriptLite-1.0.0-win-x64.zip
- SHA-256 sidecar：MouscriptLite-1.0.0-win-x64.zip.sha256

下载 ZIP 后先核对同目录 SHA-256 文件，再完整解压并运行 Anjian.App.exe。不要从 ZIP 中单独取出 EXE；运行时必须保留全部伴随文件。

## Lite 版功能范围

- 独立悬浮控制窗与完整主窗口可以同时显示；程序启动默认显示悬浮窗。
- 托盘菜单可打开主窗口、显示/隐藏悬浮窗和明确退出；关闭主窗口只隐藏窗口，不退出进程。
- 本地 Lua 脚本管理：新建、打开、保存、重命名、复制和删除。
- 全局鼠标/键盘录制，支持暂停/续录、结束录制、只记录点击坐标和鼠标移动降噪。
- 支持鼠标移动、点击、按下/释放、滚轮、键盘单键、组合键和 Unicode 文本输入。
- Lua 脚本在独立 Worker 进程中运行；支持播放、暂停、停止、循环次数和轮间隔。
- 全局快捷键：F10 播放、F11 暂停/继续、F12 中止。
- 自定义应用图标与本机设置持久化。

## 悬浮窗

悬浮窗提供录制、播放、暂停、停止、循环次数、轮间隔、只录点击、实时鼠标坐标和置顶选项。默认尺寸为 640 × 124 个逻辑像素，并根据 Windows DPI 缩放。

## Lua API 示例

    MoveTo(122, 100)
    LeftClick()
    LeftClick(100)
    RightClick(50)
    KeyPress("ENTER")
    Hotkey("CTRL", "SHIFT", "S")
    TypeText("Mouscript Lite")
    Delay(500)
    Log("本轮完成")

长按使用 LeftDown() / Delay(500) / LeftUp()。

## 当前限制

Lite 1.0.0 冻结于原 v0.1.0-preview.4 功能基线。它不包含主线后续增加的增强 IDE/调试器、图像资源管理、OCR、参数设计器、小精灵打包、插件、定时任务和多实例管理。上述能力不属于 Lite 1.0.0 的范围；后续完整产品在 Mouscript Studio 主线单独演进。

本次 Windows CI 能验证构建、测试与发布包生成，但不替代 Windows 10/11 实机测试。低级输入 Hook、DPI、多显示器、目标程序权限、托盘和长时间稳定性仍应在目标设备上验证。

## 数据兼容

为避免迁移时丢失已有数据，Lite 继续使用原本机数据目录：

- 脚本：%LOCALAPPDATA%\\Anjian2026\\Scripts
- 设置：%LOCALAPPDATA%\\Anjian2026\\settings.json

仓库名与内部程序文件名保持兼容，不影响既有脚本路径、快捷方式或配置目录。


PowerShell 开发命令：

    dotnet restore Anjian2026.sln
    dotnet build Anjian2026.sln -c Release --no-restore
    dotnet test tests/Anjian.Core.Tests/Anjian.Core.Tests.csproj -c Release
    dotnet publish src/Anjian.App/Anjian.App.csproj -c Release -r win-x64 --self-contained true