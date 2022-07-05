using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MiscUtil.Conversion;

namespace haxe_mbs_translate.src.mbs.io
{
    public class ByteArray
    {
        private Byte[][] bytes;

        private static int BUFFER_SIZE = 1024 * 8;//8;

        // allocation tracking
        public int alloc_nextIndex;

        // fast access
        private Byte[] currentBuffer;
        private int currentBufferMin = -1;
        private int currentBufferMax = -1;

        public ByteArray()
        {
            bytes = new byte[0][];
            alloc_nextIndex = 0;
        }

        private void ensureCapacity(int size)
        {
            int bufferIndex = size / BUFFER_SIZE;
            while(bytes.Length <= bufferIndex)
            {
                bytes = bytes.Append(new Byte[BUFFER_SIZE]).ToArray();
            }
        }

        private void setBuffer(int i)
        {
            currentBuffer = bytes[i];
            currentBufferMin = i * BUFFER_SIZE;
            currentBufferMax = (i + 1) * BUFFER_SIZE - 1;
        }

        public void clear()
        {
            int bufferAllocatedLength = alloc_nextIndex;
            for(int i = 0; i < bytes.Length; i++)
            {
                if (bufferAllocatedLength >= BUFFER_SIZE) Array.Fill<Byte>(bytes[i], 0);
                else if (bufferAllocatedLength > 0) Array.Fill<Byte>(bytes[i], 0, 0, bufferAllocatedLength);
                else break;
                bufferAllocatedLength -= BUFFER_SIZE;
            }
            alloc_nextIndex = 0;
        }

        public int allocate(int size)
        {
            int newBytes = alloc_nextIndex;
            alloc_nextIndex += size;
            ensureCapacity(newBytes + size);
            return newBytes;
        }

        public void writeInt(int pos, int i)
        {
            Byte[] conversion = BigEndianBitConverter.Big.GetBytes(i);

            for(int j = 0; j < conversion.Length; j++)
            {
                write(pos + j, conversion[j]);
            }
        }

        /// <summary>
        /// Float could be the c# equivalent of double - problem?
        /// </summary>
        public void writeFloat(int pos, float f)
        {
            Byte[] conversion = BigEndianBitConverter.Big.GetBytes(f);

            for (int j = 0; j < conversion.Length; j++)
            {
                write(pos + j, conversion[j]);
            }
        }

        public void writeBool(int pos, bool b)
        {
            write(pos,BigEndianBitConverter.Big.GetBytes(b)[0]);
        }

        public void writeBytes(int pos, Byte[] b)
        {
            for(int i = 0; i < b.Length; i++)
            {
                write(pos + i, b[i]);
            }
        }

        private void write(int pos, Byte b)
        {
            if(pos < currentBufferMin || pos > currentBufferMax)
            {
                setBuffer(pos / BUFFER_SIZE);
            }

            currentBuffer[pos - currentBufferMin] = b;
        }

        public void writeToFile(string loc)
        {
            FileStream fs = File.Create(loc, alloc_nextIndex);

            try
            {
                int bufferAllocatedLength = alloc_nextIndex;
                for(int i = 0; i < bytes.Length; i++)
                {
                    if (bufferAllocatedLength >= BUFFER_SIZE) fs.Write(bytes[i]);
                    else if (bufferAllocatedLength > 0) fs.Write(bytes[i].Take(bufferAllocatedLength).ToArray());
                    else break;
                    bufferAllocatedLength -= BUFFER_SIZE;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            fs.Close();
        }
    }
}
