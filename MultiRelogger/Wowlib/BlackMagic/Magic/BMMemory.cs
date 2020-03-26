using System;
using System.Runtime.InteropServices;

namespace Magic
{
	sealed public partial class BlackMagic
	{
		#region WriteMemory

        public bool Write<T>(uint adress, T value)
        {
            return Write(adress, value, typeof(T));
        }

        private bool Write(uint address, object value, Type t)
        {
            switch (Type.GetTypeCode(t))
            {
                case TypeCode.SByte:
                   return WriteSByte(address, (sbyte)value);
                case TypeCode.Byte:
                    return WriteByte(address, (byte)value);
                case TypeCode.Int16:
                    return WriteShort(address, (short)value);
                case TypeCode.UInt16:
                    return WriteUShort(address, (ushort)value);
                case TypeCode.Int32:
                    return WriteInt(address, (int)value);
                case TypeCode.UInt32:
                    return WriteUInt(address, (uint)value);
                case TypeCode.Int64:
                    return WriteInt64(address, (long)value);
                case TypeCode.UInt64:
                    return WriteUInt64(address, (ulong)value);
                case TypeCode.Single:
                    return WriteFloat(address, (float)value);
                case TypeCode.Double:
                    return WriteDouble(address, (double)value);
                case TypeCode.String:
                    var s = Convert.ToString(value);
                    return WriteUTF8String(address, s);
                default:
                    return WriteObject(address, value);
            }
        }

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <param name="nSize">Number of bytes to be written.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteBytes(uint dwAddress, byte[] Value, int nSize)
		{
			return SMemory.WriteBytes(m_hProcess, dwAddress, Value, nSize);
		}

		/// <summary>
		/// Writes a value to anotherB process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteBytes(uint dwAddress, byte[] Value)
		{
			return this.WriteBytes(dwAddress, Value, Value.Length);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteByte(uint dwAddress, byte Value)
		{
			return SMemory.WriteByte(this.m_hProcess, dwAddress, Value);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteSByte(uint dwAddress, sbyte Value)
		{
			return SMemory.WriteSByte(this.m_hProcess, dwAddress, Value);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteUShort(uint dwAddress, ushort Value)
		{
			return SMemory.WriteUShort(this.m_hProcess, dwAddress, Value);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteShort(uint dwAddress, short Value)
		{
			return SMemory.WriteShort(this.m_hProcess, dwAddress, Value);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteUInt(uint dwAddress, uint Value)
		{
			return SMemory.WriteUInt(this.m_hProcess, dwAddress, Value);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteInt(uint dwAddress, int Value)
		{
			return SMemory.WriteInt(this.m_hProcess, dwAddress, Value);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteUInt64(uint dwAddress, UInt64 Value)
		{
			return SMemory.WriteUInt64(this.m_hProcess, dwAddress, Value);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteInt64(uint dwAddress, Int64 Value)
		{
			return SMemory.WriteInt64(this.m_hProcess, dwAddress, Value);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteFloat(uint dwAddress, float Value)
		{
			return SMemory.WriteFloat(this.m_hProcess, dwAddress, Value);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteDouble(uint dwAddress, double Value)
		{
			return SMemory.WriteDouble(this.m_hProcess, dwAddress, Value);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <param name="objType">Type of object to be written (hint: use Object.GetType() or typeof(ObjectType)).</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteObject(uint dwAddress, object Value, Type objType)
		{
			return SMemory.WriteObject(this.m_hProcess, dwAddress, Value, objType);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteObject(uint dwAddress, object Value)
		{
			return SMemory.WriteObject(this.m_hProcess, dwAddress, Value, Value.GetType());
		}

        /// <summary>
        /// Writes a value to another process' memory.
        /// </summary>
        /// <param name="dwAddress">Address at which value will be written.</param>
        /// <param name="Value">Value that will be written to memory.</param>
        /// <returns>Returns true on success, false on failure.</returns>
        public bool WriteUTF8String(uint dwAddress, string Value)
        {
            return SMemory.WriteUTF8String(this.m_hProcess, dwAddress, Value);
        }

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteASCIIString(uint dwAddress, string Value)
		{
			return SMemory.WriteASCIIString(this.m_hProcess, dwAddress, Value);
		}

		/// <summary>
		/// Writes a value to another process' memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be written.</param>
		/// <param name="Value">Value that will be written to memory.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool WriteUnicodeString(uint dwAddress, string Value)
		{
			return SMemory.WriteUnicodeString(this.m_hProcess, dwAddress, Value);
		}

		#endregion

		#region ReadMemory

        public T Read<T>(params uint[] offsets)
        {
            if(offsets.Length == 0)
                throw new Exception("Invalid number of offsets passed! Must be > 0");

            // Store the type so we don't need to make a bunch of
            // typeof calls if there's a long list of offsets
            Type t = typeof (T);

            // If we only have 1 offset, there's no point in going
            // through the for loop and doing more work than needed.
            if (offsets.Length == 1)
                return (T) _Read(offsets[0], t);

            // This holds thae last offset read.
            // Once we reach offsets.Length -1, we'll return the
            // proper T type needed.
            uint last = 0;

            for (int i = 0; i < offsets.Length; i++)
            {

                // If this is the last offset in the params list
                // we need to return the T type requested.
                if (i == (offsets.Length - 1))
                    return (T)_Read(offsets[i] + last, t);

                // Keep reading from the last thing read + the next offset
                // in the params list.
                // This is the equivalent to: [[[0x404]+0x54]+0x2C]
                last = (uint)_Read(last + offsets[i], typeof(uint));
            }

            return default(T);

        }

        private object _Read(uint address, Type t)
        {
            switch (Type.GetTypeCode(t))
            {
                case TypeCode.SByte:
                    return ReadSByte(address);

                case TypeCode.Byte:
                    return ReadByte(address);

                case TypeCode.Int32:
                    return ReadInt(address);

                case TypeCode.UInt32:
                    return ReadUInt(address);

                case TypeCode.Int64:
                    return ReadInt64(address);

                case TypeCode.UInt64:
                    return ReadUInt64(address);

                case TypeCode.Single:
                    return ReadFloat(address);

                case TypeCode.Double:
                    return ReadDouble(address);

                case TypeCode.String:
                    return ReadUTF8String(address, 255);

				case TypeCode.Boolean:
            		return ReadInt(address) != 0;
                default:
                    return ReadObject(address, t);
            }
        }

        public unsafe T ReadStruct<T>(uint dwAddress) where T : struct
        {
            int tSize = Marshal.SizeOf(typeof(T));
            var data = ReadBytes(dwAddress, tSize);
            
            if (data.Length < tSize)
                throw new ArgumentException("start + struct size is more than the length of the byte array!", "start");

            fixed (byte* str = &data[0])
            {
                return (T)Marshal.PtrToStructure(new IntPtr(str), typeof(T));
            }
        }

        public T ReadStruct<T>(long address) where T : struct
        {
            return ReadStruct<T>(Convert.ToUInt32(address));
        }

		/// <summary>
		/// Reads a value from memory
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="nSize">Number of bytes to read from memory.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public byte[] ReadBytes(uint dwAddress, int nSize)
		{
			if (!this.m_bProcessOpen || this.m_hProcess == IntPtr.Zero)
				throw new Exception("Process is not open for read/write.");

			return SMemory.ReadBytes(this.m_hProcess, dwAddress, nSize);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public byte ReadByte(uint dwAddress)
		{
			if (!this.m_bProcessOpen || this.m_hProcess == IntPtr.Zero)
				throw new Exception("Process is not open for read/write.");

			return SMemory.ReadByte(this.m_hProcess, dwAddress);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public sbyte ReadSByte(uint dwAddress)
		{
			if (!this.m_bProcessOpen || this.m_hProcess == IntPtr.Zero)
				throw new Exception("Process is not open for read/write.");

			return SMemory.ReadSByte(this.m_hProcess, dwAddress);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public ushort ReadUShort(uint dwAddress)
		{
			return this.ReadUShort(dwAddress, false);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public ushort ReadUShort(uint dwAddress, bool bReverse)
		{
			if (!this.m_bProcessOpen || this.m_hProcess == IntPtr.Zero)
				throw new Exception("Process is not open for read/write.");

			return SMemory.ReadUShort(this.m_hProcess, dwAddress, bReverse);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public short ReadShort(uint dwAddress)
		{
			return this.ReadShort(dwAddress, false);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public short ReadShort(uint dwAddress, bool bReverse)
		{
			if (!this.m_bProcessOpen || this.m_hProcess == IntPtr.Zero)
				throw new Exception("Process is not open for read/write.");

			return SMemory.ReadShort(this.m_hProcess, dwAddress, bReverse);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public uint ReadUInt(uint dwAddress)
		{
			return this.ReadUInt(dwAddress, false);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public uint ReadUInt(uint dwAddress, bool bReverse)
		{
			if (!this.m_bProcessOpen || this.m_hProcess == IntPtr.Zero)
				throw new Exception("Process is not open for read/write.");

			return SMemory.ReadUInt(this.m_hProcess, dwAddress, bReverse);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public int ReadInt(uint dwAddress)
		{
			return this.ReadInt(dwAddress, false);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public int ReadInt(uint dwAddress, bool bReverse)
		{
			if (!this.m_bProcessOpen || this.m_hProcess == IntPtr.Zero)
				throw new Exception("Process is not open for read/write.");

			return SMemory.ReadInt(this.m_hProcess, dwAddress, bReverse);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public UInt64 ReadUInt64(uint dwAddress)
		{
			return this.ReadUInt64(dwAddress, false);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public UInt64 ReadUInt64(uint dwAddress, bool bReverse)
		{
			if (!this.m_bProcessOpen || this.m_hProcess == IntPtr.Zero)
				throw new Exception("Process is not open for read/write.");

			return SMemory.ReadUInt64(this.m_hProcess, dwAddress, bReverse);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public Int64 ReadInt64(uint dwAddress)
		{
			return this.ReadInt64(dwAddress, false);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public Int64 ReadInt64(uint dwAddress, bool bReverse)
		{
			if (!this.m_bProcessOpen || this.m_hProcess == IntPtr.Zero)
				throw new Exception("Process is not open for read/write.");

			return SMemory.ReadInt64(this.m_hProcess, dwAddress, bReverse);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public float ReadFloat(uint dwAddress)
		{
			return this.ReadFloat(dwAddress, false);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public float ReadFloat(uint dwAddress, bool bReverse)
		{
			if (!this.m_bProcessOpen || this.m_hProcess == IntPtr.Zero)
				throw new Exception("Process is not open for read/write.");

			return SMemory.ReadFloat(this.m_hProcess, dwAddress, bReverse);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public double ReadDouble(uint dwAddress)
		{
			return this.ReadDouble(dwAddress, false);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="bReverse">Determines whether bytes read will be reversed or not (Little endian or big endian).  Usually 'false'.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		/// <remarks>Sometimes one needs to read a value where the most significant bytes is not first (i.e. when reading a network packet from memory).  In this case, one would specify 'true' for the bReverse parameter to get the value in a readable format.</remarks>
		public double ReadDouble(uint dwAddress, bool bReverse)
		{
			if (!this.m_bProcessOpen || this.m_hProcess == IntPtr.Zero)
				throw new Exception("Process is not open for read/write.");

			return SMemory.ReadDouble(this.m_hProcess, dwAddress, bReverse);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="objType">Type of object to be read (hint: use Object.GetType() or typeof(ObjectType) macro).</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public object ReadObject(uint dwAddress, Type objType)
		{
			if (!this.m_bProcessOpen || this.m_hProcess == IntPtr.Zero)
				throw new Exception("Process is not open for read/write.");

			return SMemory.ReadObject(this.m_hProcess, dwAddress, objType);
		}

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="nLength">Maximum number of characters to be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public string ReadASCIIString(uint dwAddress, int nLength)
		{
			return SMemory.ReadASCIIString(this.m_hProcess, dwAddress, nLength);
		}

        public string ReadUTF8String(uint dwAdress, int nLength)
        {
            return SMemory.ReadUTF8String(this.m_hProcess, dwAdress, nLength);
        }

		/// <summary>
		/// Reads a value from memory.
		/// </summary>
		/// <param name="dwAddress">Address at which value will be read.</param>
		/// <param name="nLength">Maximum number of characters to be read.</param>
		/// <exception cref="Exception">Throws general exception on failure.</exception>
		/// <returns>Returns the value that was read from memory.</returns>
		public string ReadUnicodeString(uint dwAddress, int nLength)
		{
			return SMemory.ReadUnicodeString(this.m_hProcess, dwAddress, nLength);
		}
		#endregion

		#region AllocateFreeMemory
		/// <summary>
		/// Allocates memory inside the opened process.
		/// </summary>
		/// <param name="nSize">Number of bytes to allocate.</param>
		/// <param name="dwAllocationType">Type of memory allocation.  See <see cref="MemoryAllocType"/>.</param>
		/// <param name="dwProtect">Type of memory protection.  See <see cref="MemoryProtectType"/></param>
		/// <returns>Returns NULL on failure, or the base address of the allocated memory on success.</returns>
		public uint AllocateMemory(int nSize, uint dwAllocationType, uint dwProtect)
		{
			return SMemory.AllocateMemory(m_hProcess, nSize, dwAllocationType, dwProtect);
		}

		/// <summary>
		/// Allocates memory inside the opened process.
		/// </summary>
		/// <param name="nSize">Number of bytes to allocate.</param>
		/// <returns>Returns NULL on failure, or the base address of the allocated memory on success.</returns>
		/// <remarks>
		/// Allocates memory using <see cref="MemoryAllocType.MEM_COMMIT"/> and <see cref="MemoryProtectType.PAGE_EXECUTE_READWRITE"/>.
		/// </remarks>
		public uint AllocateMemory(int nSize)
		{
			return AllocateMemory(nSize, MemoryAllocType.MEM_COMMIT, MemoryProtectType.PAGE_EXECUTE_READWRITE);
		}

		/// <summary>
		/// Allocates memory inside the opened process.
		/// </summary>
		/// <returns>Returns NULL on failure, or the base address of the allocated memory on success.</returns>
		/// <remarks>
		/// Allocates 0x1000 bytes of memory using <see cref="MemoryAllocType.MEM_COMMIT"/> and <see cref="MemoryProtectType.PAGE_EXECUTE_READWRITE"/>.
		/// </remarks>
		public uint AllocateMemory()
		{
			return AllocateMemory(SMemory.DEFAULT_MEMORY_SIZE);
		}

		/// <summary>
		/// Frees an allocated block of memory in the opened process.
		/// </summary>
		/// <param name="dwAddress">Base address of the block of memory to be freed.</param>
		/// <param name="nSize">Number of bytes to be freed.  This must be zero (0) if using <see cref="MemoryFreeType.MEM_RELEASE"/>.</param>
		/// <param name="dwFreeType">Type of free operation to use.  See <see cref="MemoryFreeType"/>.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		public bool FreeMemory(uint dwAddress, int nSize, uint dwFreeType)
		{
			return SMemory.FreeMemory(m_hProcess, dwAddress, nSize, dwFreeType);
		}

		/// <summary>
		/// Frees an allocated block of memory in the opened process.
		/// </summary>
		/// <param name="dwAddress">Base address of the block of memory to be freed.</param>
		/// <returns>Returns true on success, false on failure.</returns>
		/// <remarks>
		/// Frees a block of memory using <see cref="MemoryFreeType.MEM_RELEASE"/>.
		/// </remarks>
		public bool FreeMemory(uint dwAddress)
		{
			return FreeMemory(dwAddress, /*size must be 0 for MEM_RELEASE*/ 0, MemoryFreeType.MEM_RELEASE);
		}
		#endregion

        public bool IsValid(uint dwAddress)
        {
            return SMemory.IsValid(m_hProcess, dwAddress);
        }
	}
}