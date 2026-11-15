# Mouscript Lite 1.0.0 范围冻结

- 产品：Mouscript Lite
- 版本：1.0.0
- 源码基线：v0.1.0-preview.4，原始发布提交 08886d9e66c08ba24f6f1b7d9e91bbdaeba8a9e0
- 代码线：release/lite-1.0.0
- 发布类型：稳定 Release（非 prerelease）
- 平台：Windows 10/11 x64
- Runtime：WinForms + .NET 10 + Lua 5.4

## 冻结原则

Lite 只承接 preview.4 已发布功能。此次升级只修改产品显示名称、版本号、悬浮窗尺寸与 DPI 缩放、产品包名和发布元数据；不把 preview.5 或 main 后续功能合并进来。

## 功能包含

- 主窗口、独立悬浮窗、托盘生命周期与多尺寸应用图标
- 本地 Lua 脚本文件管理和基础文本编辑
- 鼠标/键盘录制、暂停续录、click-only、事件合并和输入过滤
- Lua Worker 运行、播放/暂停/停止和输入清理
- 循环次数、轮间隔与 F10/F11/F12 快捷键
- 本地配置持久化

## 明确不包含

- M3 增强编辑器、断点/单步调试
- 可视化动作列表、窗口相对坐标录制
- 图像资源、找图/找色、OCR
- 脚本参数设计器、自定义 UI、小精灵打包
- 插件、受控文件/网络 API、定时任务与多实例管理

## 兼容性

- 不改 Anjian.App.exe 文件名和 Anjian2026 本机数据目录，避免影响原 preview.4 用户数据。
- 继续使用原 Lua API 语义，不静默变更旧脚本解释。
- Lite 独立在 release/lite-1.0.0 发布分支，不接受 main 后续提交的自动合并。

## 验证边界

Windows Actions 必须完成 Restore、Release Build、Core tests、self-contained publish、ZIP/SHA256 与 Release 创建。真实 Windows 10/11 桌面、Hook、DPI/多屏、托盘和长时稳定性测试未获得设备结果前继续标记 NOT RUN；CI 通过不等于实机验收通过。