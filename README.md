# 基于 Unity GameFramework 的 3D 塔防游戏

一款采用 **Unity Game Framework（GF）** 框架架构打造的 **3D 塔防游戏**，数据驱动、分层清晰、支持多语言与多关卡。

## 项目介绍

本项目以 **Unity Game Framework** 为底层架构，结合 **UniTask** 与 **protobuf-net**，实现了一套完整且可扩展的 3D 塔防玩法：

- **多种防御塔**：箭塔（Archer）、激光塔（Laser）、能量塔（EnergyPylon）、电磁发生器（EMPGenerator）、魔法塔（Magic）、导弹阵列（MissileArray）；每种塔支持多等级成长（`TowerLevel` 数据表驱动）。
- **敌人与波次**：敌人类型、波次与波次元素由 `Enemy` / `Wave` / `WaveElement` 数据表配置，每关独立关卡数据（`Level`）。
- **数据驱动**：遵循 GF 的 DataTable 机制，塔、敌人、武器、关卡、商店、声音、UI 等全部以数据表（`.txt` / `.bytes`）配置，便于调参与扩展。
- **关卡流程**：包含 `GameStart`、`Menu`、`Level1`、`Level2`、`Level3` 等场景，具备开始、暂停、通关、失败等流程控制（`LevelControl` / `LevelManager` / `LevelPath`）。
- **经济与商店**：资源获取与消耗、商店（`ShopItem`）、道具（`Item` / `BonusItem`）。
- **本地化**：内置简体中文、繁体中文、英文多语言（`Localization`）。
- **战斗通行证**：包含 `BattlePass` / `BattlePassGolden` 等系统配置。

## 项目介绍视频

📺 [项目介绍视频](在此处粘贴你的 B站 / YouTube 链接)

## 技术栈与架构

- **引擎**：Unity 2023.2.20f1c1
- **框架**：Unity Game Framework（GF）——实体、事件、有限状态机（FSM）、配置中心、UI 框架、对象池、声音管理等
- **异步**：UniTask
- **序列化/网络配置**：protobuf-net
- **语言**：C#

## 目录结构

    Assets/
    ├── GameFramework/     框架库
    ├── GameMain/          游戏主体
    │   ├── Configs/
    │   ├── DataTables/
    │   ├── Entity/
    │   ├── Scenes/
    │   ├── Scripts/
    │   ├── UI/
    │   └── ...
    └── Plugins/           第三方库（UniTask、protobuf-net）

## 运行方式

1. 使用 **Unity Hub** 打开项目，选择 Unity **2023.2.20f1c1**。
2. 等待包导入与脚本编译完成。
3. 打开主场景（`GameStart` 或对应关卡场景）运行。

## 参考资料

- Unity Game Framework（GF）：https://github.com/EllanJiang/GameFramework
