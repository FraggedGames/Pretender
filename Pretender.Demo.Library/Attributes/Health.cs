using System;
using Pretender.Entities.Attributes;
using Pretender.Entities.Combat;

namespace Pretender.Demo.Library.Attributes
{
    public class Health : EntityAttribute
    {
        public override Int32 Base => 100;

        public override Int32 Calculate()
        {
            Total = Base;
            foreach (var item in Entity.Equipment)
            {
                Total += item.Stamina * 2;
            }

            return Total;
        }

        protected override void Subscribe()
        {
            Entity.EquipmentChanged += Entity_EquipmentChanged;
            Entity.DamageReceived += Entity_DamageReceived;
        }

        protected override void Unsubscribe()
        {
            Entity.EquipmentChanged -= Entity_EquipmentChanged;
            Entity.DamageReceived -= Entity_DamageReceived;
        }

        private void Entity_EquipmentChanged(Object sender, EventArgs e) => Calculate();

        private void Entity_DamageReceived(Object sender, DamageEventArgs e) => Current -= e.Damage.Amount;
    }
}
