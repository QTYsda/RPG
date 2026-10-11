# RPG —— Unity 2D 俯视角 RPG Demo

用 Unity 2022.3 做的 2D 俯视角 RPG 原型：八方向移动、射箭与近战、敌人状态机 AI、
ScriptableObject 技能树、高低层地形与属性成长。

**在线试玩**：(https://qtysda.github.io/RPG/)

**演示视频**：【待填：B 站链接】

## 玩法与操作

| 操作 | 按键 |
| --- | --- |
| 移动 | `W` `A` `S` `D` 或方向键（八方向） |
| 射箭 | `K`（0.5 秒冷却，射箭期间锁定移动） |
| 近战 | `J` |
| 切换装备 | `P` |

## 已实现的功能

### 玩家

- **八方向移动**：合成 Horizontal / Vertical 输入得到速度向量；朝向随水平输入翻转（`localScale` 取反）
- **多方向射箭**：瞄准方向取当前输入方向，0.5 秒冷却；射箭期间锁定移动，并切换到上半身动画层
- **近战攻击**：攻击判定触发，命中后目标进入击退与僵直
- **生命值与受击**：`PlayerHealth` 管理血量，受击期间进入击退状态，不响应移动输入

### 敌人 AI

- **状态机**：`Idle` / `Chasing` / `Attacking` / `Knockback` 四态
- **玩家检测**：`Physics2D.OverlapCircleAll` 在检测点半径内查找玩家
- **追击与攻击**：只在进入攻击距离且冷却结束时攻击，冷却期间继续追击
- **受击**：击退状态期间暂停行为逻辑

### 技能树与成长

- `SkillSO`（ScriptableObject）定义技能数据，技能以 `.asset` 资产形式配置
- `SkillSlot` 管理槽位，`SkillTreeManger` 处理技能点消费与前置解锁校验
- 升级事件驱动 UI 刷新（`ToggleSkillTree`、`StatsUI`）
- `数值管理器`（单例）统一管理属性，`经验管理器` 负责经验与升级

### 场景交互

- `Elevation_Entry` / `Elevation_Exit`：高低层区域的进出与碰撞层切换

## 技术点

| 用到的 | 用在哪里 | 为什么这么做 |
| --- | --- | --- |
| 单例 | 数值管理器 | 属性只能有一份，改动集中在一个入口 |
| 事件驱动 | 战斗 → UI | 战斗逻辑不直接引用 UI，以后加新 UI 不用动战斗代码 |
| ScriptableObject | 技能数据 | 数据和逻辑分离，改技能数值不用改代码、不用重编译 |
| 状态机 | 敌人 AI | 行为切换集中在一处，新增状态只加一个分支 |
| 动画层叠加 | 射箭 | 上半身射箭、下半身移动，两层互不干扰 |
| Cinemachine | 相机跟随 | 不用手写跟随插值 |

## 遇到的问题与解决

> 这一节是面试官最会追问的地方，建议自己补 2–3 条真实的。（下面是格式示例）

- **问题**：射箭时角色还能移动，瞄准方向跟着乱
  **定位**：射箭动画和移动共用同一套输入，两套逻辑同时生效
  **解决**：射箭状态把速度置零并锁住移动输入，退出状态再解锁

## 目录结构

```
Assets/
  脚本/                 全部 C# 逻辑
    玩家/               移动、射箭、战斗、生命值
    敌人/               移动与状态机、生命值、击退
    技能树/             技能数据、槽位、技能树 UI
  预制体/               Prefab
  Scenes/               场景（主场景 SampleScene.unity）
  场景图像/ 动画/ UI图像/ 动态石头/    美术资源
  Grass Tiles/          瓦片素材
  TextMesh Pro/         TMP 内置资源
  UOSLauncherEncrypt/   Unity UOS 启动器加密模块
Packages/               manifest.json
ProjectSettings/        Unity 工程设置
```

仓库不包含 `Library/`、`Logs/`、`UserSettings/` 等本地缓存目录，首次打开工程时 Unity 会自己重建。

## 如何运行

1. 安装 Unity `2022.3.62f3c1`（2022.3 LTS，其他补丁版本通常也能打开）。
2. Unity Hub → **Add project from disk** → 选中本仓库根目录。
3. 打开 `Assets/Scenes/SampleScene.unity`，点播放。
4. 首次打开会重新导入资源并生成 `Library/`，视机器性能需要几分钟。

## 素材来源

- 项目美术（场景图像 / 动画 / UI图像 / 动态石头）： 来自itch.co的"Tiny Swords"资源包
- TextMesh Pro 内置资源：Unity 官方包

## 说明

本项目为个人学习作品。
