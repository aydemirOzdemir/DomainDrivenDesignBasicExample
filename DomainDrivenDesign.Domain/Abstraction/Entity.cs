﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesign.Domain.Abstraction;

public abstract class Entity:IEquatable<Entity>
{
    public Guid Id { get; init; }
    public Entity(Guid id)
    {
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (obj is not Entity entity) return false;
        if (obj.GetType() != GetType()) return false;
        return entity.Id == Id;

    }

    public bool Equals(Entity? other)
    {
        if (other == null) return false;
        if (other is not Entity entity) return false;
        if (other.GetType() != GetType()) return false;
        return entity.Id == Id;
    }
}
