using UnityEngine;
using Unity.Networking.Transport;

public struct StateMessage : INetworkMessage
{
    public int tick;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 velocity;
    public Vector3 angularVelocity;

    public Vector3 Position { get => position; set => position = value; }

    public void Serialize(ref DataStreamWriter writer)
    {
        writer.WriteInt(tick);
        writer.WriteFloat(Position.x);
        writer.WriteFloat(Position.y);
        writer.WriteFloat(Position.z);
        writer.WriteFloat(rotation.x);
        writer.WriteFloat(rotation.y);
        writer.WriteFloat(rotation.z);
        writer.WriteFloat(rotation.w);
        writer.WriteFloat(velocity.x);
        writer.WriteFloat(velocity.y);
        writer.WriteFloat(velocity.z);
        writer.WriteFloat(angularVelocity.x);
        writer.WriteFloat(angularVelocity.y);
        writer.WriteFloat(angularVelocity.z);
    }

    public static StateMessage Deserialize(ref DataStreamReader reader)
    {
        return new()
        {
            tick = reader.ReadInt(),
            Position = new()
            {
                x = reader.ReadFloat(),
                y = reader.ReadFloat(),
                z = reader.ReadFloat()
            },
            rotation = new()
            {
                x = reader.ReadFloat(),
                y = reader.ReadFloat(),
                z = reader.ReadFloat(),
                w = reader.ReadFloat()
            },
            velocity = new()
            {
                x = reader.ReadFloat(),
                y = reader.ReadFloat(),
                z = reader.ReadFloat()
            },
            angularVelocity = new()
            {
                x = reader.ReadFloat(),
                y = reader.ReadFloat(),
                z = reader.ReadFloat()
            }
        };
    }

    public override string ToString()
    {
        return $"tick={tick}, " +
            $"position={Position}, " +
            $"rotation={rotation}, " +
            $"velocity={velocity}, " +
            $"angularVelocity={angularVelocity}";
    }
}