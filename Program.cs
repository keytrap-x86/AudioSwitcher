using CoreAudio;

namespace AudioSwitcher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MMDeviceEnumerator deviceEnum = new(Guid.NewGuid());

            var currentDevice = deviceEnum.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);

            foreach (MMDevice device in deviceEnum.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
            {
                if (currentDevice != null)
                {
                    if (device.ID != currentDevice.ID)
                    {
                        deviceEnum.SetDefaultAudioEndpoint(device);
                        break;
                    }
                }
            }
        }
    }
}