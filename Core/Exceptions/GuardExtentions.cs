using System;
using FamTrees.Core.Entities.PersonAggregate;
using FamTrees.Core.Entities.TreeAggregate;
using FamTrees.Core.Exceptions;

namespace Ardalis.GuardClauses
{
    public static class PersonGuards
    {
        public static void NullTree(this IGuardClause guardClause, int treeId, Tree tree)
        {
            if (tree == null)
                throw new TreeNotFoundException(treeId);
        }
        public static Sex UnknownSex(this IGuardClause guardClause, Sex sex)
        {
            if (!Enum.IsDefined(typeof(Sex), sex))
                throw new InvalidEnumSexValueException();
            return sex;
        }
        public static void DeadBeforeBorn(this IGuardClause guardClause, DateTime born, DateTime death)
        {
            if (DateTime.Compare(born, death) > 0)
                throw new PersonDeadBeforeBornException();
        }
        public static void DateInFuture(this IGuardClause guardClause, DateTime date, string parameterName)
        {
            if (DateTime.Compare(date, DateTime.Now) > 0)
                throw new DateInFutureException(parameterName + " can't be in the future");
        }
        public static void KidOlderThanParent(this IGuardClause guardClause, DateTime personBirthDate, DateTime parentBirthDate)
        {
            if (DateTime.Compare(parentBirthDate, personBirthDate) >= 0)
                throw new PersonOlderThanParentException("Child cannot be older than parent");
        }
    }
}