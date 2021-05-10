using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Test.CustomConstraints
{
    public class RemoveFirstAndLastCharacterConstraint : Constraint
    {
        readonly string _expected;
        public RemoveFirstAndLastCharacterConstraint(string expected)
        {
            _expected = expected.Remove(expected.Length - 1).Remove(0,1);
            Description = $"Expected is {expected}";
        }
        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            if (typeof(TActual) != typeof(string))
                return new ConstraintResult(this, actual, ConstraintStatus.Error);
            if (_expected == actual.ToString())
                return new ConstraintResult(this, actual, ConstraintStatus.Success);
            else
                return new ConstraintResult(this, actual, ConstraintStatus.Failure);
        }
    }
    public class Is : NUnit.Framework.Is
    {
        public static RemoveFirstAndLastCharacterConstraint RemoveFirstAndLastCharacter(string expected)
        {
            return new RemoveFirstAndLastCharacterConstraint(expected);
        }
    }
}
