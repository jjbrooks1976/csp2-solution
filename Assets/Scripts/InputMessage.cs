using System.Collections.Generic;
using UnityEngine;
using Unity.Networking.Transport;

public struct InputMessage : INetworkMessage
{
    public int startTick;
    public List<UserInput> inputs;

    public void Serialize(ref DataStreamWriter writer)
    {
        writer.WriteInt(startTick);
        writer.WriteInt(inputs.Count);
        foreach (UserInput input in inputs)
        {
            input.Serialize(ref writer);
        }
    }

    public static InputMessage Deserialize(ref DataStreamReader reader)
    {
        InputMessage message = new()
        {
            startTick = reader.ReadInt(),
            inputs = new List<UserInput>()
        };

        int count = reader.ReadInt();
        for (int i = 0; i < count; i++)
        {
            message.inputs.Add(UserInput.Deserialize(ref reader));
        }

        return message;
    }

    public override string ToString()
    {
        return $"startTick={startTick}, " +
            $"inputCount={inputs.Count}, " +
            $"inputs=({string.Join("),(", inputs)})";
    }
}