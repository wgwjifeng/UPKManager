﻿using UpkManager.Domain.Helpers;


namespace UpkManager.Domain.Models.Tables {

  public class DomainGenerationTableEntry : DomainUpkBuilderBase {

    #region Properties

    public int ExportTableCount { get; set; }

    public int NameTableCount { get; set; }

    public int NetObjectCount { get; set; }

    #endregion Properties

    #region Domain Methods

    public void ReadGenerationTableEntry(ByteArrayReader data) {
      ExportTableCount = data.ReadInt32();
      NameTableCount   = data.ReadInt32();
      NetObjectCount   = data.ReadInt32();
    }

    #endregion Domain Methods

    #region DomainUpkBuilderBase Implementation

    public override int GetBuilderSize() {
      BuilderSize = sizeof(int) * 3;

      return BuilderSize;
    }

    #endregion DomainUpkBuilderBase Implementation

  }

}
