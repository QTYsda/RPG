# RPG

一个使用 Unity 制作的 2D 类银河恶魔城 / 横版 RPG 学习项目。

## 开发环境

| 项目 | 版本 |
| --- | --- |
| Unity 编辑器 | `2022.3.62f3c1` (Unity 2022.3 LTS) |
| 渲染管线 | 内置管线（URP 未启用） |
| 主要包 | Cinemachine 2.10.7、2D Feature 2.0.1、Timeline 1.7.7、TextMeshPro 3.0.7 |

## 已实现的功能

- **玩家**：横版移动、跳跃、射箭（`Arrow`）、近战战斗、生命值系统、装备切换
- **敌人**：巡逻 / 追击移动、生命值、受击击退、战斗状态机
- **技能树**：技能数据 `SkillSO`、技能槽位 `SkillSlot`、技能树 UI 与管理器
- **数值与成长**：`数值管理器`、`经验管理器`、`StatsUI` 属性面板
- **场景交互**：`Elevation_Entry` / `Elevation_Exit` 实现高低层区域切换

## 目录结构

```
Assets/
  脚本/            全部 C# 逻辑
    玩家/          玩家控制、战斗、生命值
    敌人/          敌人 AI、受击与击退
    技能树/        技能系统与技能树 UI
  预制体/          Prefab
  场景/            Scene
  场景图像/ 动画/ UI图像/ 动态石头/   美术资源
  Grass Tiles/    瓦片与场景素材
  TextMesh Pro/   TMP 内置资源
  UOSLauncherEncrypt/   Unity UOS 启动器加密模块
Packages/
  manifest.json   依赖清单
ProjectSettings/  Unity 工程设置
```

## 如何运行

1. 安装 Unity Hub 与 Unity `2022.3.62f3c1`（2022.3 LTS 其他补丁版本通常也可用）。
2. 用 Unity Hub 的 **Add → Add project from disk** 选中本仓库根目录。
3. 首次打开会重新导入资源并生成 `Library/`，视机器性能需要几分钟。
4. 打开 `Assets/场景` 下的场景，点击播放即可。

> 仓库中不包含 `Library/`、`Logs/`、`UserSettings/` 等本地缓存目录，属于正常现象。

## 说明

本项目为个人学习作品。
