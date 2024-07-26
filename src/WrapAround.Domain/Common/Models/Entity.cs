﻿
namespace WrapAround.Domain.Common.Models;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; }

    protected Entity(Guid id)
    {
        Id = id;
    }

    public static bool operator ==(Entity left, Entity right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !Equals(left, right);
    }

    public bool Equals(Entity? other)
    {
        return Equals((object?)other);
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity entity && Id.Equals(entity.Id);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}
