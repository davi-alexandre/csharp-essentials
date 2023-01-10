namespace Two.WellFormedTypes
{
    internal struct Measure
    {
        public Measure(int units, int subunits)
        {
            Units = units;
            SubUnits = subunits;
        }

        public int Units { get; }
        public int SubUnits { get; }

        public bool Equals(Measure m)
        {
            if (m.GetHashCode() != GetHashCode())
                return false;

            return (Units == m.Units)
                && (SubUnits == m.SubUnits);
        }

        public override int GetHashCode()
        {
            int result = Units.GetHashCode();

            if (Units.GetHashCode() != SubUnits.GetHashCode())
                result ^= SubUnits.GetHashCode();

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            return Equals((Measure)obj);
        }

        public override string ToString()
        {
            return "MEASURE: " + Units + ", " + SubUnits;
        }
    }

    internal struct Mass
    {
        public Mass(int kg, int g, int mg)
        {
            Kg = kg;
            G = g;
            Mg = mg;
        }

        public int Kg { get; }
        public int G { get; }
        public int Mg { get; }

        public bool Equals(Mass m)
        {
            if (GetHashCode() != m.GetHashCode())
                return false;

            return (Kg == m.Kg)
                && (G == m.G)
                && (Mg == m.Mg);
        }

        public override int GetHashCode()
        {
            int hashCode = Mg.GetHashCode() | (G.GetHashCode() << 1);

            if (hashCode != Kg.GetHashCode())
                hashCode ^= Kg.GetHashCode();

            return hashCode;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            return Equals((Mass)obj);
        }

        public override string ToString()
        {
            return string.Format("MASS: {0} (kg) \t{1} (g) \t{2} (mg)\n",
                Kg, G, Mg);
        }
    }

    internal class MyPhysicalObject : object
    {
        public MyPhysicalObject(int mass, int measure)
        {
            Mass = new Mass(mass, mass, mass);
            Measure = new Measure(measure, measure);
        }

        public Mass Mass { get; set; }
        public Measure Measure { get; set; }

        public bool Equals(MyPhysicalObject o)
        {
            if (o == null)
                return false;
            if (ReferenceEquals(o, this))
                return true;

            if (GetHashCode() != o.GetHashCode())
                return false;

            return Mass.Equals(o.Mass)
                && Measure.Equals(o.Measure);
        }

        public override int GetHashCode()
        {
            int hashCode = Mass.GetHashCode();

            if (hashCode == Measure.GetHashCode())
                hashCode ^= (Measure.GetHashCode() << 1);
            else
                hashCode ^= Measure.GetHashCode();

            return hashCode;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            return Equals((MyPhysicalObject)obj);
        }

        public override string ToString()
        {
            return Measure.ToString() + "\n"
                + Mass.ToString();
        }
    }

    internal class MyMetaPhysicalObject : MyPhysicalObject
    {
        public MyMetaPhysicalObject(int mass, int measure, int gayness)
            : base(mass, measure)
        {
            Gayness = gayness;
        }

        public int Gayness { get; set; }

        public bool Equals(MyMetaPhysicalObject o)
        {
            if (o == null)
                return false;
            if (ReferenceEquals(this, o))
                return true;

            if (GetHashCode() != o.GetHashCode())
                return false;
            if (!base.Equals(o))
                return false;

            return Gayness.Equals(o.Gayness);
        }

        public override int GetHashCode()
        {
            int hashCode = Gayness.GetHashCode();

            if (hashCode != base.GetHashCode())
                hashCode ^= base.GetHashCode();

            return hashCode;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            return Equals((MyMetaPhysicalObject)obj);
        }

        public override string ToString()
        {
            return base.ToString() + "\n" +
                "GAYNESS: " + Gayness;
        }
    }
}
