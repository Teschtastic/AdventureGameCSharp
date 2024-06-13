namespace AdventureGame.NPCs
{
    public class NPC
    {
        public NPC(string n, string d, int cH, int mH, int aC, int aD, bool isF, bool isA, string eA, bool hEA, string eW, bool hEW, List<string> inv)
        {
            Name                = n;
            Dialogue            = d;
            CurrentHealth       = cH;
            MaximumHealth       = mH;
            ArmorClass          = aC;
            AttackDamage        = aD;
            IsFriendly          = isF;
            IsAlive             = isA;
            EquippedArmor       = eA;
            HasEquippedArmor    = hEA;
            EquippedWeapon      = eW;
            HasEquippedWeapon   = hEW;
            Inventory           = inv;
        }

        public string       Name                { get; set; }
        public string       Dialogue            { get; set; }
        public int          CurrentHealth       { get; set; }
        public int          MaximumHealth       { get; set; }
        public int          ArmorClass          { get; set; }
        public int          AttackDamage        { get; set; }
        public bool         IsFriendly          { get; set; }
        public bool         IsAlive             { get; set; }
        public string       EquippedArmor       { get; set; }
        public bool         HasEquippedArmor    { get; set; }
        public string       EquippedWeapon      { get; set; }
        public bool         HasEquippedWeapon   { get; set; }
        public List<string> Inventory           { get; set; }

        public override string ToString()
        {
            return "\n\nNPC Description:\n\n" +
                    "Name:            " + Name + "\n" +
                    "Current health:  " + CurrentHealth + "\n" +
                    "Maximum health:  " + MaximumHealth + "\n" +
                    "Armor class:     " + ArmorClass + "\n" +
                    "Attack damage:   " + AttackDamage + "\n" +
                    "Equipped armor:  " + EquippedArmor + "\n" +
                    "Equipped weapon: " + EquippedWeapon;
        }
    }
}
