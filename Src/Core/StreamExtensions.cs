using System;
using System.IO;

namespace NEbml.Core
{
	public static class StreamExtensions
	{
        public static int ReadFully(this Stream stream, Span<byte> buffer)
        {
            int bytesRead = 0;
            int totalBytesRead = 0;
            Span<byte> _buffer;

            do
            {
                _buffer = buffer.Slice(totalBytesRead, totalBytesRead);
                bytesRead = stream.Read(_buffer);
                totalBytesRead += bytesRead;
            } while (bytesRead > 0 && totalBytesRead < buffer.Length);

            return totalBytesRead;
        }
    }
}
