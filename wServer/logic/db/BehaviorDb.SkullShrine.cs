﻿#region

using System;
using wServer.logic.attack;
using wServer.logic.loot;
using wServer.logic.movement;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private static _ SkullShrine = Behav()
            .Init(0x0d56, Behaves("Skull Shrine",
                NullBehavior.Instance,
                Cooldown.Instance(750, PredictiveMultiAttack.Instance(25, 10*(float) Math.PI/180, 9, 1)),
                IfNot.Instance(
                    Once.Instance(new RunBehaviors(
                        SpawnMinionImmediate.Instance(0x0d57, 5, 8, 10),
                        SpawnMinionImmediate.Instance(0x0d58, 5, 4, 8)
                        )),
                    Cooldown.Instance(5000,
                        If.Instance(
                            EntityGroupLesserThan.Instance(10, 20, "Flaming Skulls"),
                            Rand.Instance(
                                SpawnMinionImmediate.Instance(0x0d57, 5, 2, 4),
                                SpawnMinionImmediate.Instance(0x0d58, 5, 2, 4)
                                )
                            )
                        )
                    ), new LootBehavior(LootDef.Empty,
                        Tuple.Create(100, new LootDef(0, 3, 0, 8,
                            Tuple.Create(0.003, (ILoot) new ItemLoot("Orb of Conflict")),
                            Tuple.Create(0.015, (ILoot) new TierLoot(11, ItemType.Weapon)),
                            Tuple.Create(0.015, (ILoot) new TierLoot(11, ItemType.Armor)),
                            Tuple.Create(0.015, (ILoot) new TierLoot(5, ItemType.Ring)),
                            Tuple.Create(0.025, (ILoot) new TierLoot(10, ItemType.Weapon)),
                            Tuple.Create(0.025, (ILoot) new TierLoot(10, ItemType.Armor)),
                            Tuple.Create(0.035, (ILoot) new TierLoot(9, ItemType.Weapon)),
                            Tuple.Create(0.035, (ILoot) new TierLoot(5, ItemType.Ability)),
                            Tuple.Create(0.035, (ILoot) new TierLoot(9, ItemType.Armor)),
                            //Tuple.Create(0.05, (ILoot)new StatPotionsLoot(1, 2)),
                            Tuple.Create(0.055, (ILoot) new TierLoot(4, ItemType.Ring)),
                            Tuple.Create(0.15, (ILoot) new TierLoot(4, ItemType.Ability)),
                            Tuple.Create(0.15, (ILoot) new TierLoot(8, ItemType.Armor)),
                            Tuple.Create(0.25, (ILoot) new TierLoot(8, ItemType.Weapon)),
                            Tuple.Create(0.25, (ILoot) new TierLoot(7, ItemType.Armor)),
                            Tuple.Create(0.25, (ILoot) new TierLoot(3, ItemType.Ring))
                            )),
                        Tuple.Create(100, new LootDef(1, 3, 1, 3,
                            Tuple.Create(0.045, (ILoot) new StatPotionsLoot(1, 2))
                            ))
                        )
                ))
            .Init(0x0d57, Behaves("Red Flaming Skull",
                IfNot.Instance(
                    Chasing.Instance(2, 20, 3, 0x0d56),
                    SimpleWandering.Instance(2, .5f)
                    ),
                Cooldown.Instance(750, PredictiveMultiAttack.Instance(15, 5*(float) Math.PI/180, 2, 1))
                ))
            .Init(0x0d58, Behaves("Blue Flaming Skull",
                IfNot.Instance(
                    Circling.Instance(15, 20, 20, 0x0d56),
                    SimpleWandering.Instance(20)
                    ),
                Cooldown.Instance(750, PredictiveMultiAttack.Instance(15, 5*(float) Math.PI/180, 2, 1))
                ));
    }
}