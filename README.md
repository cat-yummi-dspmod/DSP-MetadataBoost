# Property Boost | 元数据快速增�?
在右下角小猫面板（前�?YummiUIHarness）的「元数据作弊」页里提供快速增加统计的按钮（与 MetadataNoCost 共用该页）�?
On the shared **Metadata Cheats** page of the cat panel (requires YummiUIHarness; shared with MetadataNoCost), buttons quickly boost Metadata statistics.

## 功能 Features

- **正式进入游戏后自动打开**本页（可在页内用复选框关闭，配置项 `General/AutoOpenOnEnter`），�?**F9** 可再次打开/关闭
- 3个按钮：
  - **1�?矩阵**：为6种矩阵各增加 10,000 点生产和消�?  - **1�?矩阵**：为6种矩阵各增加 100,000,000 点生产和消�?  - **10�?矩阵**：为6种矩阵各增加 1,000,000,000 点生产和消�?- 同时增加跨存档和存档内的记录
- 保持数据一致�?
- **The page opens when entering a game** (turn off with the checkbox on the page, config `General/AutoOpenOnEnter`), press **F9** to toggle
- 3 buttons:
  - **1�?Matrix**: Add 10,000 production and consumption for 6 matrix types
  - **1�?Matrix**: Add 100,000,000 production and consumption for 6 matrix types
  - **10�?Matrix**: Add 1,000,000,000 production and consumption for 6 matrix types
- Updates both cross-save and in-save records
- Maintains data consistency

## 使用方法 Usage

1. 进入游戏后按 **F9** 键或点右下角小猫按钮打开面板
2. 点击按钮增加对应数量的元数据
3. 增加的是**生产和消�?*，所以实际可用元数据不变
4. 但是存档统计数据会增加，可以解锁成就

1. Press **F9** or click the cat button in the bottom-right corner after entering game
2. Click buttons to add the corresponding amount of Metadata
3. Adds both **production and consumption**, so available Metadata remains the same
4. But save statistics increase, can unlock achievements

## 工作原理 How It Works

每次点击按钮�?- 跨存档生产记�?+= 数量
- 存档内生产记�?+= 数量
- 跨存档消耗记�?+= 数量
- 存档内消耗记�?+= 数量

因为生产和消耗增加相同，所以：
```
可用元数�?= (旧生�?+ 数量) - (旧消�?+ 数量) - 当前存档生产
          = 旧生�?- 旧消�?- 当前存档生产
          = 不变
```

但是累计生产和消耗都增加了，可以用于解锁成就�?
Each button click:
- Cross-save production += amount
- In-save production += amount
- Cross-save consumption += amount
- In-save consumption += amount

Since production and consumption increase equally:
```
Available Metadata = (old production + amount) - (old consumption + amount) - current save production
                   = old production - old consumption - current save production
                   = unchanged
```

But cumulative production and consumption both increase, which can unlock achievements.

## 注意事项 Notes

- 仅影响当前存�?- 不影响可用元数据�?- 主要用于快速增加统计数�?
- Only affects current save
- Doesn't affect available Metadata amount
- Mainly used to quickly increase statistics

## 兼容�?Compatibility

- 游戏版本 Game Version: 0.10.31.24571+
- 与其�?mod 兼容 Compatible with other mods

## 更新日志 Changelog

### 1.1.0
- 自带窗口改为 YummiUIHarness 面板中的一页；「进入游戏后自动打开」改为页内复选框
- The built-in window became a page in the YummiUIHarness panel; "open on entering a game" is now a checkbox on the page

### 1.0.0
- 初始版本
- 进入游戏自动弹出�?个按钮：1万�?亿�?0�?- Initial release
- Auto-pop on enter, 3 buttons: 1�? 1�? 10�?