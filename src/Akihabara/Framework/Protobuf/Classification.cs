// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: mediapipe/framework/formats/classification.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Akihabara.Framework.Protobuf {

  /// <summary>Holder for reflection information generated from mediapipe/framework/formats/classification.proto</summary>
  public static partial class ClassificationReflection {

    #region Descriptor
    /// <summary>File descriptor for mediapipe/framework/formats/classification.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static ClassificationReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjBtZWRpYXBpcGUvZnJhbWV3b3JrL2Zvcm1hdHMvY2xhc3NpZmljYXRpb24u",
            "cHJvdG8SHGFraWhhYmFyYS5mcmFtZXdvcmsucHJvdG9idWYiUwoOQ2xhc3Np",
            "ZmljYXRpb24SDQoFaW5kZXgYASABKAUSDQoFc2NvcmUYAiABKAISDQoFbGFi",
            "ZWwYAyABKAkSFAoMZGlzcGxheV9uYW1lGAQgASgJIloKEkNsYXNzaWZpY2F0",
            "aW9uTGlzdBJECg5jbGFzc2lmaWNhdGlvbhgBIAMoCzIsLmFraWhhYmFyYS5m",
            "cmFtZXdvcmsucHJvdG9idWYuQ2xhc3NpZmljYXRpb25CRQoiY29tLmdvb2ds",
            "ZS5tZWRpYXBpcGUuZm9ybWF0cy5wcm90b0ITQ2xhc3NpZmljYXRpb25Qcm90",
            "b6ICCU1lZGlhUGlwZQ=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Akihabara.Framework.Protobuf.Classification), global::Akihabara.Framework.Protobuf.Classification.Parser, new[]{ "Index", "Score", "Label", "DisplayName" }, null, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::Akihabara.Framework.Protobuf.ClassificationList), global::Akihabara.Framework.Protobuf.ClassificationList.Parser, new[]{ "Classification" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class Classification : pb::IMessage<Classification> {
    private static readonly pb::MessageParser<Classification> _parser = new pb::MessageParser<Classification>(() => new Classification());
    private pb::UnknownFieldSet _unknownFields;
    private int _hasBits0;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<Classification> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Akihabara.Framework.Protobuf.ClassificationReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Classification() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Classification(Classification other) : this() {
      _hasBits0 = other._hasBits0;
      index_ = other.index_;
      score_ = other.score_;
      label_ = other.label_;
      displayName_ = other.displayName_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public Classification Clone() {
      return new Classification(this);
    }

    /// <summary>Field number for the "index" field.</summary>
    public const int IndexFieldNumber = 1;
    private readonly static int IndexDefaultValue = 0;

    private int index_;
    /// <summary>
    /// The index of the class in the corresponding label map.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int Index {
      get { if ((_hasBits0 & 1) != 0) { return index_; } else { return IndexDefaultValue; } }
      set {
        _hasBits0 |= 1;
        index_ = value;
      }
    }
    /// <summary>Gets whether the "index" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasIndex {
      get { return (_hasBits0 & 1) != 0; }
    }
    /// <summary>Clears the value of the "index" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearIndex() {
      _hasBits0 &= ~1;
    }

    /// <summary>Field number for the "score" field.</summary>
    public const int ScoreFieldNumber = 2;
    private readonly static float ScoreDefaultValue = 0F;

    private float score_;
    /// <summary>
    /// The probability score for this class.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Score {
      get { if ((_hasBits0 & 2) != 0) { return score_; } else { return ScoreDefaultValue; } }
      set {
        _hasBits0 |= 2;
        score_ = value;
      }
    }
    /// <summary>Gets whether the "score" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasScore {
      get { return (_hasBits0 & 2) != 0; }
    }
    /// <summary>Clears the value of the "score" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearScore() {
      _hasBits0 &= ~2;
    }

    /// <summary>Field number for the "label" field.</summary>
    public const int LabelFieldNumber = 3;
    private readonly static string LabelDefaultValue = "";

    private string label_;
    /// <summary>
    /// Label or name of the class.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Label {
      get { return label_ ?? LabelDefaultValue; }
      set {
        label_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }
    /// <summary>Gets whether the "label" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasLabel {
      get { return label_ != null; }
    }
    /// <summary>Clears the value of the "label" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearLabel() {
      label_ = null;
    }

    /// <summary>Field number for the "display_name" field.</summary>
    public const int DisplayNameFieldNumber = 4;
    private readonly static string DisplayNameDefaultValue = "";

    private string displayName_;
    /// <summary>
    /// Optional human-readable string for display purposes.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string DisplayName {
      get { return displayName_ ?? DisplayNameDefaultValue; }
      set {
        displayName_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }
    /// <summary>Gets whether the "display_name" field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasDisplayName {
      get { return displayName_ != null; }
    }
    /// <summary>Clears the value of the "display_name" field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearDisplayName() {
      displayName_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as Classification);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(Classification other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Index != other.Index) return false;
      if (!pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.Equals(Score, other.Score)) return false;
      if (Label != other.Label) return false;
      if (DisplayName != other.DisplayName) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (HasIndex) hash ^= Index.GetHashCode();
      if (HasScore) hash ^= pbc::ProtobufEqualityComparers.BitwiseSingleEqualityComparer.GetHashCode(Score);
      if (HasLabel) hash ^= Label.GetHashCode();
      if (HasDisplayName) hash ^= DisplayName.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (HasIndex) {
        output.WriteRawTag(8);
        output.WriteInt32(Index);
      }
      if (HasScore) {
        output.WriteRawTag(21);
        output.WriteFloat(Score);
      }
      if (HasLabel) {
        output.WriteRawTag(26);
        output.WriteString(Label);
      }
      if (HasDisplayName) {
        output.WriteRawTag(34);
        output.WriteString(DisplayName);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (HasIndex) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(Index);
      }
      if (HasScore) {
        size += 1 + 4;
      }
      if (HasLabel) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Label);
      }
      if (HasDisplayName) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(DisplayName);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(Classification other) {
      if (other == null) {
        return;
      }
      if (other.HasIndex) {
        Index = other.Index;
      }
      if (other.HasScore) {
        Score = other.Score;
      }
      if (other.HasLabel) {
        Label = other.Label;
      }
      if (other.HasDisplayName) {
        DisplayName = other.DisplayName;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            Index = input.ReadInt32();
            break;
          }
          case 21: {
            Score = input.ReadFloat();
            break;
          }
          case 26: {
            Label = input.ReadString();
            break;
          }
          case 34: {
            DisplayName = input.ReadString();
            break;
          }
        }
      }
    }

  }

  /// <summary>
  /// Group of Classification protos.
  /// </summary>
  public sealed partial class ClassificationList : pb::IMessage<ClassificationList> {
    private static readonly pb::MessageParser<ClassificationList> _parser = new pb::MessageParser<ClassificationList>(() => new ClassificationList());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<ClassificationList> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Akihabara.Framework.Protobuf.ClassificationReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ClassificationList() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ClassificationList(ClassificationList other) : this() {
      classification_ = other.classification_.Clone();
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public ClassificationList Clone() {
      return new ClassificationList(this);
    }

    /// <summary>Field number for the "classification" field.</summary>
    public const int ClassificationFieldNumber = 1;
    private static readonly pb::FieldCodec<global::Akihabara.Framework.Protobuf.Classification> _repeated_classification_codec
        = pb::FieldCodec.ForMessage(10, global::Akihabara.Framework.Protobuf.Classification.Parser);
    private readonly pbc::RepeatedField<global::Akihabara.Framework.Protobuf.Classification> classification_ = new pbc::RepeatedField<global::Akihabara.Framework.Protobuf.Classification>();
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pbc::RepeatedField<global::Akihabara.Framework.Protobuf.Classification> Classification {
      get { return classification_; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as ClassificationList);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(ClassificationList other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if(!classification_.Equals(other.classification_)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      hash ^= classification_.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      classification_.WriteTo(output, _repeated_classification_codec);
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      size += classification_.CalculateSize(_repeated_classification_codec);
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(ClassificationList other) {
      if (other == null) {
        return;
      }
      classification_.Add(other.classification_);
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            classification_.AddEntriesFrom(input, _repeated_classification_codec);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
