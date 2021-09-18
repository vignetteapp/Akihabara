// Copyright 2021 (c) homuler and The Vignette Authors
// Licensed under MIT
// See LICENSE for details

// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: mediapipe/modules/face_geometry/protos/face_geometry.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace Akihabara.Framework.Protobuf.FaceGeometry {

  /// <summary>Holder for reflection information generated from mediapipe/modules/face_geometry/protos/face_geometry.proto</summary>
  public static partial class FaceGeometryReflection {

    #region Descriptor
    /// <summary>File descriptor for mediapipe/modules/face_geometry/protos/face_geometry.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static FaceGeometryReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "CjptZWRpYXBpcGUvbW9kdWxlcy9mYWNlX2dlb21ldHJ5L3Byb3Rvcy9mYWNl",
            "X2dlb21ldHJ5LnByb3RvEipha2loYWJhcmEuZnJhbWV3b3JrLnByb3RvYnVm",
            "LmZhY2VfZ2VvbWV0cnkaLW1lZGlhcGlwZS9mcmFtZXdvcmsvZm9ybWF0cy9t",
            "YXRyaXhfZGF0YS5wcm90bxo0bWVkaWFwaXBlL21vZHVsZXMvZmFjZV9nZW9t",
            "ZXRyeS9wcm90b3MvbWVzaF8zZC5wcm90byKZAQoMRmFjZUdlb21ldHJ5EkAK",
            "BG1lc2gYASABKAsyMi5ha2loYWJhcmEuZnJhbWV3b3JrLnByb3RvYnVmLmZh",
            "Y2VfZ2VvbWV0cnkuTWVzaDNkEkcKFXBvc2VfdHJhbnNmb3JtX21hdHJpeBgC",
            "IAEoCzIoLmFraWhhYmFyYS5mcmFtZXdvcmsucHJvdG9idWYuTWF0cml4RGF0",
            "YUI+Ciljb20uZ29vZ2xlLm1lZGlhcGlwZS5tb2R1bGVzLmZhY2VnZW9tZXRy",
            "eUIRRmFjZUdlb21ldHJ5UHJvdG8="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::Akihabara.Framework.Protobuf.MatrixDataReflection.Descriptor, global::Akihabara.Framework.Protobuf.FaceGeometry.Mesh3DReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::Akihabara.Framework.Protobuf.FaceGeometry.FaceGeometry), global::Akihabara.Framework.Protobuf.FaceGeometry.FaceGeometry.Parser, new[]{ "Mesh", "PoseTransformMatrix" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// Defines the face geometry pipeline estimation result format.
  /// </summary>
  public sealed partial class FaceGeometry : pb::IMessage<FaceGeometry> {
    private static readonly pb::MessageParser<FaceGeometry> _parser = new pb::MessageParser<FaceGeometry>(() => new FaceGeometry());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<FaceGeometry> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::Akihabara.Framework.Protobuf.FaceGeometry.FaceGeometryReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FaceGeometry() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FaceGeometry(FaceGeometry other) : this() {
      mesh_ = other.HasMesh ? other.mesh_.Clone() : null;
      poseTransformMatrix_ = other.HasPoseTransformMatrix ? other.poseTransformMatrix_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public FaceGeometry Clone() {
      return new FaceGeometry(this);
    }

    /// <summary>Field number for the "mesh" field.</summary>
    public const int MeshFieldNumber = 1;
    private global::Akihabara.Framework.Protobuf.FaceGeometry.Mesh3d mesh_;
    /// <summary>
    /// Defines a mesh surface for a face. The face mesh vertex IDs are the same as
    /// the face landmark IDs.
    ///
    /// XYZ coordinates exist in the right-handed Metric 3D space configured by an
    /// environment. UV coodinates are taken from the canonical face mesh model.
    ///
    /// XY coordinates are guaranteed to match the screen positions of
    /// the input face landmarks after (1) being multiplied by the face pose
    /// transformation matrix and then (2) being projected with a perspective
    /// camera matrix of the same environment.
    ///
    /// NOTE: the triangular topology of the face mesh is only useful when derived
    ///       from the 468 face landmarks, not from the 6 face detection landmarks
    ///       (keypoints). The former don't cover the entire face and this mesh is
    ///       defined here only to comply with the API. It should be considered as
    ///       a placeholder and/or for debugging purposes.
    ///
    ///       Use the face geometry derived from the face detection landmarks
    ///       (keypoints) for the face pose transformation matrix, not the mesh.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Akihabara.Framework.Protobuf.FaceGeometry.Mesh3d Mesh {
      get { return mesh_; }
      set {
        mesh_ = value;
      }
    }
    /// <summary>Gets whether the mesh field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasMesh {
      get { return mesh_ != null; }
    }
    /// <summary>Clears the value of the mesh field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearMesh() {
      mesh_ = null;
    }

    /// <summary>Field number for the "pose_transform_matrix" field.</summary>
    public const int PoseTransformMatrixFieldNumber = 2;
    private global::Akihabara.Framework.Protobuf.MatrixData poseTransformMatrix_;
    /// <summary>
    /// Defines a face pose transformation matrix, which provides mapping from
    /// the static canonical face model to the runtime face. Tries to distinguish
    /// a head pose change from a facial expression change and to only reflect the
    /// former.
    ///
    /// Is a 4x4 matrix and contains only the following components:
    ///   * Uniform scale
    ///   * Rotation
    ///   * Translation
    ///
    /// The last row is guaranteed to be `[0 0 0 1]`.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public global::Akihabara.Framework.Protobuf.MatrixData PoseTransformMatrix {
      get { return poseTransformMatrix_; }
      set {
        poseTransformMatrix_ = value;
      }
    }
    /// <summary>Gets whether the pose_transform_matrix field is set</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool HasPoseTransformMatrix {
      get { return poseTransformMatrix_ != null; }
    }
    /// <summary>Clears the value of the pose_transform_matrix field</summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void ClearPoseTransformMatrix() {
      poseTransformMatrix_ = null;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as FaceGeometry);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(FaceGeometry other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (!object.Equals(Mesh, other.Mesh)) return false;
      if (!object.Equals(PoseTransformMatrix, other.PoseTransformMatrix)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (HasMesh) hash ^= Mesh.GetHashCode();
      if (HasPoseTransformMatrix) hash ^= PoseTransformMatrix.GetHashCode();
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
      if (HasMesh) {
        output.WriteRawTag(10);
        output.WriteMessage(Mesh);
      }
      if (HasPoseTransformMatrix) {
        output.WriteRawTag(18);
        output.WriteMessage(PoseTransformMatrix);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (HasMesh) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(Mesh);
      }
      if (HasPoseTransformMatrix) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(PoseTransformMatrix);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(FaceGeometry other) {
      if (other == null) {
        return;
      }
      if (other.HasMesh) {
        if (!HasMesh) {
          Mesh = new global::Akihabara.Framework.Protobuf.FaceGeometry.Mesh3d();
        }
        Mesh.MergeFrom(other.Mesh);
      }
      if (other.HasPoseTransformMatrix) {
        if (!HasPoseTransformMatrix) {
          PoseTransformMatrix = new global::Akihabara.Framework.Protobuf.MatrixData();
        }
        PoseTransformMatrix.MergeFrom(other.PoseTransformMatrix);
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
          case 10: {
            if (!HasMesh) {
              Mesh = new global::Akihabara.Framework.Protobuf.FaceGeometry.Mesh3d();
            }
            input.ReadMessage(Mesh);
            break;
          }
          case 18: {
            if (!HasPoseTransformMatrix) {
              PoseTransformMatrix = new global::Akihabara.Framework.Protobuf.MatrixData();
            }
            input.ReadMessage(PoseTransformMatrix);
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
