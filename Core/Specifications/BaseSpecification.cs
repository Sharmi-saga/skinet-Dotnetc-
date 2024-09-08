using System;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using Core.Interfaces;

namespace Core.Specifications;

public class BaseSpecification<T>(Expression<Func<T, bool>> criteria): ISpecification<T>
{
    protected BaseSpecification () : this(null){}

    public Expression<Func<T, bool>>? Criteria => criteria;
}
