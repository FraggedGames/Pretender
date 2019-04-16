using System;
using Pretender.Entities.Attributes;
using Pretender.Items.Equipment.Armor;

namespace Pretender.Demo.Library.Attributes
{
    public class Armor : EntityAttribute
    {
        public override Int32 Calculate()
        {
            Total = Base;
            foreach (var item in Entity.Equipment)
            {
                if (item is IArmor armor)
                {
                    Total += armor.Armor;
                }
            }

            return Total;
        }

        protected override void Subscribe()
        {
            Entity.EquipmentChanged += Entity_EquipmentChanged;
        }

        protected override void Unsubscribe() => Entity.EquipmentChanged -= Entity_EquipmentChanged;

        private void Entity_EquipmentChanged(Object sender, EventArgs e) => Calculate();
    }
}
