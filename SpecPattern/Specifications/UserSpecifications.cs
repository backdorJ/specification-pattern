using System.Linq.Expressions;
using SpecPattern.Models;

namespace SpecPattern.Specifications;

public class UserSpecifications
{
    public static Expression<Func<User, bool>> IsActive = x => x.IsActive;
}