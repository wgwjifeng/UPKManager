﻿using System.Threading.Tasks;

using UpkManager.Domain.Helpers;


namespace UpkManager.Domain.Models.Compression {

  public class DomainCompressedChunk : DomainUpkBuilderBase {

    #region Properties

    public int UncompressedOffset { get; set; }

    public int UncompressedSize { get; set; }

    public int CompressedOffset { get; set; }

    public int CompressedSize { get; set; }

    public DomainCompressedChunkHeader Header { get; set; }

    #endregion Properties

    #region Domain Methods

    public virtual async Task ReadCompressedChunk(ByteArrayReader reader) {
      UncompressedOffset = reader.ReadInt32();
      UncompressedSize   = reader.ReadInt32();

      CompressedOffset = reader.ReadInt32();
      CompressedSize   = reader.ReadInt32();

      Header = new DomainCompressedChunkHeader();

      await Header.ReadCompressedChunkHeader(reader.Branch(CompressedOffset), 1, UncompressedSize, CompressedSize);
    }

    #endregion Domain Methods

    #region DomainUpkBuilderBase Implementation

    public override int GetBuilderSize() {
      BuilderSize = sizeof(int) * 4;

      return BuilderSize;
    }

    #endregion DomainUpkBuilderBase Implementation

  }

}
