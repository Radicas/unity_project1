# Unity项目 Windows 环境搭建教程（从0到1）

## 📋 目录
1. [系统要求检查](#1-系统要求检查)
2. [安装Unity Hub](#2-安装unity-hub)
3. [安装Unity编辑器](#3-安装unity编辑器)
4. [打开项目](#4-打开项目)
5. [配置项目依赖](#5-配置项目依赖)
6. [验证安装](#6-验证安装)
7. [首次构建测试](#7-首次构建测试)
8. [常见问题解决](#8-常见问题解决)

---

## 1. 系统要求检查

### 1.1 检查Windows版本
- **要求**：Windows 10 (64位) 或 Windows 11 (64位)
- **检查方法**：
  1. 按 `Win + R` 键
  2. 输入 `winver` 并回车
  3. 查看Windows版本信息

### 1.2 检查系统配置
- **内存**：至少 8GB RAM（推荐 16GB）
- **硬盘空间**：至少 20GB 可用空间（用于Unity和项目）
- **显卡**：支持 DirectX 11 的独立显卡或集成显卡

**检查方法**：
1. 右键点击"此电脑" → 属性
2. 查看"已安装的内存(RAM)"
3. 查看C盘可用空间

### 1.3 检查网络连接
- 确保网络连接正常（下载Unity和依赖包需要网络）
- 如果网络受限，可能需要配置代理

---

## 2. 安装Unity Hub

### 2.1 下载Unity Hub
1. 打开浏览器，访问：https://unity.com/download
2. 点击 **"Download Unity Hub"** 按钮
3. 下载 `UnityHubSetup.exe` 文件（约100MB）

### 2.2 安装Unity Hub
1. 双击下载的 `UnityHubSetup.exe`
2. 如果出现"Windows保护了你的电脑"提示，点击 **"更多信息"** → **"仍要运行"**
3. 在安装向导中：
   - 选择安装路径（默认：`C:\Program Files\Unity Hub`）
   - 勾选"创建桌面快捷方式"（推荐）
   - 点击 **"安装"**
4. 等待安装完成（约1-2分钟）
5. 点击 **"完成"**，Unity Hub会自动启动

### 2.3 登录Unity账号
1. 如果还没有Unity账号：
   - 点击 **"Create account"** 创建账号
   - 或访问 https://id.unity.com/ 注册
   - **注意**：免费个人版即可，无需付费
2. 如果已有账号：
   - 输入邮箱和密码登录
   - 或使用Google/Apple账号登录

---

## 3. 安装Unity编辑器

### 3.1 添加Unity版本
1. 在Unity Hub中，点击左侧 **"Installs"** 标签
2. 点击右上角的 **"Install Editor"** 按钮
3. 在版本列表中找到 **"2022.3.34f1c1"**
   - 如果找不到，点击 **"Archive"** 标签查找
   - 或访问 https://unity.com/releases/editor/archive 下载
4. 点击该版本右侧的 **"Install"** 按钮

### 3.2 选择安装模块
在安装配置界面，**必须勾选以下模块**：

#### 必需模块：
- ✅ **Microsoft Visual Studio Community 2022**（代码编辑器，推荐）
- ✅ **Windows Build Support (IL2CPP)**（Windows平台构建支持）
- ✅ **Windows Build Support (Mono)**（Windows平台构建支持）

#### 可选但推荐：
- ✅ **Android Build Support**（如果将来要构建Android版本）
- ✅ **Android SDK & NDK Tools**
- ✅ **OpenJDK**

**注意**：
- 如果只构建Windows版本，可以不选Android相关模块
- 但项目包含Android配置，建议一起安装

### 3.3 开始安装
1. 确认选择的模块后，点击右下角 **"Install"** 按钮
2. 等待下载和安装（**这可能需要30分钟到2小时**，取决于网速）
   - 总大小约 5-8 GB
   - 可以最小化窗口，在后台下载
3. 安装完成后，Unity Hub会显示绿色对勾 ✅

---

## 4. 打开项目

### 4.1 添加项目到Unity Hub
1. 在Unity Hub中，点击左侧 **"Projects"** 标签
2. 点击右上角 **"Add"** 或 **"添加"** 按钮
3. 浏览到项目文件夹：`C:\Repos\unity_demo`
4. 选择该文件夹，点击 **"选择文件夹"**

### 4.2 选择Unity版本
1. 如果项目文件夹被添加，Unity Hub会检测项目需要的Unity版本
2. 如果提示"需要Unity版本"，点击 **"打开"** 或 **"Open"**
3. Unity Hub会自动使用已安装的 2022.3.34f1c1 版本打开项目

### 4.3 首次打开项目
1. Unity编辑器会自动启动
2. 首次打开会显示 **"Importing Assets"** 进度条
3. 等待资源导入完成（**可能需要5-15分钟**）
   - 进度条会显示导入进度
   - 不要关闭Unity编辑器

---

## 5. 配置项目依赖

### 5.1 等待包管理器下载依赖
1. Unity打开后，查看底部 **"Console"** 窗口
2. 查看顶部菜单栏右侧的 **"Packages"** 状态
3. 如果显示下载进度，等待完成

### 5.2 检查包管理器
1. 点击菜单栏 **"Window"** → **"Package Manager"**
2. 在左侧列表查看已安装的包
3. 确保以下包已安装：
   - Unity Ads
   - Unity Analytics
   - TextMesh Pro
   - 2D Sprite
   - Timeline

### 5.3 解决依赖问题
如果出现错误或警告：

#### 错误：包下载失败
**解决方法**：
1. 点击菜单栏 **"Edit"** → **"Preferences"** → **"Package Manager"**
2. 检查网络设置
3. 如果在中国大陆，可能需要配置代理
4. 或手动下载包：
   - 访问 https://packages.unity.com/
   - 下载缺失的包
   - 通过 **"Package Manager"** → **"+"** → **"Add package from disk"** 添加

#### 警告：缺少某些包
**解决方法**：
1. 在 **"Package Manager"** 中搜索缺失的包
2. 点击 **"Install"** 安装

---

## 6. 验证安装

### 6.1 检查项目状态
1. 查看 **"Console"** 窗口（底部）
2. 确保没有红色错误（Errors）
3. 黄色警告（Warnings）通常可以忽略

### 6.2 检查场景
1. 在 **"Project"** 窗口（左侧）中，展开 `Assets/Scenes`
2. 双击 `MainMenu.unity` 打开主菜单场景
3. 点击顶部播放按钮 ▶️ 测试运行
4. 如果游戏正常运行，说明配置成功！

### 6.3 检查关键脚本
1. 在 **"Project"** 窗口中，展开 `Assets/Scripts`
2. 检查以下关键脚本是否存在：
   - `Manager/GameManager.cs`
   - `Manager/PlayerManager.cs`
   - `KienCode/DataController.cs`
3. 如果脚本显示正常，说明项目完整

---

## 7. 首次构建测试

### 7.1 构建Windows版本
1. 点击菜单栏 **"File"** → **"Build Settings"**
2. 在平台列表中选择 **"PC, Mac & Linux Standalone"**
3. 点击 **"Switch Platform"**（如果需要切换）
4. 等待平台切换完成

### 7.2 配置构建设置
1. 在 **"Build Settings"** 窗口中：
   - **Target Platform**: Windows
   - **Architecture**: x86_64 (64-bit)
   - **Scripting Backend**: Mono（推荐）或 IL2CPP
2. 点击 **"Player Settings"** 按钮
3. 在 **"Player Settings"** 中检查：
   - **Company Name**: Ohze Game Studio
   - **Product Name**: Rescue Hero
   - **Default Icon**: 已设置

### 7.3 执行构建
1. 回到 **"Build Settings"** 窗口
2. 点击 **"Build"** 按钮
3. 选择输出文件夹（例如：`C:\Repos\unity_demo\Builds\Windows`）
4. 点击 **"选择文件夹"**
5. 等待构建完成（**可能需要5-20分钟**）
6. 构建完成后，会在输出文件夹生成 `.exe` 文件

### 7.4 测试构建的游戏
1. 导航到构建输出文件夹
2. 双击 `.exe` 文件运行游戏
3. 测试游戏功能是否正常

---

## 8. 常见问题解决

### 问题1：Unity Hub无法下载Unity编辑器
**症状**：下载速度很慢或失败

**解决方法**：
1. 检查网络连接
2. 尝试使用VPN或代理
3. 手动下载Unity编辑器：
   - 访问 https://unity.com/releases/editor/archive
   - 下载 Unity 2022.3.34f1c1
   - 在Unity Hub中，点击 **"Installs"** → **"Locate"** 选择已下载的安装包

### 问题2：项目打开时出现大量错误
**症状**：Console窗口显示红色错误

**解决方法**：
1. 检查Unity版本是否正确（必须是 2022.3.34f1c1）
2. 等待所有资源导入完成
3. 点击菜单栏 **"Assets"** → **"Reimport All"**
4. 如果仍有错误，检查具体错误信息：
   - 缺少脚本 → 检查Scripts文件夹是否完整
   - 缺少资源 → 检查Assets文件夹是否完整

### 问题3：包管理器无法下载包
**症状**：Package Manager显示下载失败

**解决方法**：
1. 检查网络连接
2. 清除Unity缓存：
   - 关闭Unity
   - 删除 `C:\Users\你的用户名\AppData\Local\Unity\cache`
   - 重新打开Unity
3. 手动配置包注册表：
   - 点击 **"Edit"** → **"Project Settings"** → **"Package Manager"**
   - 检查注册表配置

### 问题4：构建时出现编译错误
**症状**：构建失败，显示C#编译错误

**解决方法**：
1. 检查Console窗口的具体错误信息
2. 确保所有脚本文件完整
3. 检查是否有语法错误
4. 尝试清理项目：
   - 删除 `Library` 文件夹
   - 重新打开Unity（会自动重新生成）

### 问题5：游戏运行时崩溃
**症状**：点击播放按钮后Unity崩溃

**解决方法**：
1. 检查系统内存是否充足
2. 降低Unity编辑器质量设置：
   - **Edit** → **Preferences** → **General** → 降低 **Graphics Emulation**
3. 检查显卡驱动是否最新
4. 尝试以管理员身份运行Unity

### 问题6：找不到某些资源文件
**症状**：场景中显示粉色方块（缺失资源）

**解决方法**：
1. 检查 `Assets` 文件夹是否完整
2. 检查 `.meta` 文件是否存在
3. 如果资源确实缺失，可能需要从版本控制系统重新获取

---

## 9. 下一步操作

### 9.1 熟悉Unity界面
- **Scene视图**：编辑场景
- **Game视图**：预览游戏
- **Hierarchy**：场景对象列表
- **Project**：项目资源
- **Inspector**：对象属性
- **Console**：日志和错误

### 9.2 学习项目结构
- 查看 `Assets/Scripts` 了解代码结构
- 查看 `Assets/Scenes` 了解场景
- 查看 `Assets/Resources` 了解资源

### 9.3 开始开发
- 修改代码：使用Visual Studio或VS Code
- 编辑场景：在Unity编辑器中
- 测试运行：点击播放按钮
- 构建发布：使用Build Settings

---

## 10. 快速参考命令

### Unity Hub快捷键
- `Ctrl + N`: 新建项目
- `Ctrl + O`: 打开项目

### Unity编辑器快捷键
- `Ctrl + S`: 保存场景
- `Ctrl + Shift + S`: 保存所有
- `Ctrl + P`: 播放/暂停
- `Ctrl + Shift + P`: 停止播放
- `F`: 聚焦选中对象
- `Ctrl + D`: 复制对象
- `Delete`: 删除对象

### 重要菜单路径
- **File → Build Settings**: 构建设置
- **Edit → Project Settings**: 项目设置
- **Window → Package Manager**: 包管理器
- **Assets → Reimport All**: 重新导入所有资源

---

## 11. 获取帮助

### 官方资源
- Unity官方文档：https://docs.unity3d.com/
- Unity论坛：https://forum.unity.com/
- Unity学习：https://learn.unity.com/

### 项目相关
- 查看项目代码注释
- 检查Console窗口的错误信息
- 搜索Unity官方文档

---

## ✅ 完成检查清单

在开始开发前，确认以下所有项目已完成：

- [ ] Unity Hub已安装并登录
- [ ] Unity 2022.3.34f1c1已安装
- [ ] 项目已成功打开，无错误
- [ ] 所有依赖包已下载
- [ ] 项目可以正常播放运行
- [ ] Windows构建测试成功
- [ ] 熟悉Unity基本操作

---

## 🎉 恭喜！

如果你完成了以上所有步骤，说明你的开发环境已经搭建成功！

现在你可以：
- 开始修改和开发游戏
- 测试游戏功能
- 构建发布版本

**祝你开发顺利！** 🚀

---

*最后更新：2024年*
*适用项目：unity_demo (Rescue Hero)*

