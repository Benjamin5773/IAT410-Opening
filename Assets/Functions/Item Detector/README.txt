通过向玩家子类添加Trigger，检测是否有Item标签的物体在Trigger范围内。如果存在，则在UI中显示交互提示，并且玩家可以通过交互按键实现拾取。
1. InteractLabel 放入UI画布子类
2. ItemDetector 放入玩家子类
3. ItemDetector 中，Interact Label 填入场景中的 InteractLabel
4. 为物品GameObject添加Item标签