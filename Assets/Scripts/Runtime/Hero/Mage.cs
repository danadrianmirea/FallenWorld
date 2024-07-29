
using Game.Runtime.Skill.Controler;

namespace Game.Runtime.Actor.Hero
{
    public class Mage : Hero
    {
        protected override void SetModelOfWeapon(Item.Definition.Equipment item)
        {
            equipmentAsVisualModel.SetModelOfWeapon(item, HeroType.Mage);
        }

        protected override void SetModelOfOffHand(Item.Definition.Equipment item)
        {
            equipmentAsVisualModel.SetModelOfOffHand(item, HeroType.Mage);
        }

        protected override void SetModelOfHelmet(Item.Definition.Equipment item)
        {
            equipmentAsVisualModel.SetModelOfHelmet(item, HeroType.Mage);
        }

        protected override void SetModelOfChest(Item.Definition.Equipment item)
        {
            equipmentAsVisualModel.SetModelOfChest(item, HeroType.Mage);
        }

        protected override void InitializeBasicAttack()
        {
            _normalAttackControler = InitializeShootNormalAttack();
            base.InitializeBasicAttack();
        }

        private NormalAttackShoot InitializeShootNormalAttack()
        {
            ISpellControler _createdNormalAttack = _spellBuilder.CreateShootNormalAttack();
            _createdNormalAttack.Initialize();
            NormalAttackShoot _shootNormalAttackControler = (NormalAttackShoot)_createdNormalAttack;
            _shootNormalAttackControler.InitializeForRightButtonBechaviour();

            return _shootNormalAttackControler;
        }
    }
}