// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: association_auth_contract.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace AElf.Client.AssociationAuth {

  /// <summary>Holder for reflection information generated from association_auth_contract.proto</summary>
  public static partial class AssociationAuthContractReflection {

    #region Descriptor
    /// <summary>File descriptor for association_auth_contract.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static AssociationAuthContractReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "Ch9hc3NvY2lhdGlvbl9hdXRoX2NvbnRyYWN0LnByb3RvGgxjbGllbnQucHJv",
            "dG8ipAIKDE9yZ2FuaXphdGlvbhIjChtwcm9wb3Nlcl9hdXRob3JpdHlfcmVx",
            "dWlyZWQYASABKAgSLQoUb3JnYW5pemF0aW9uX2FkZHJlc3MYAiABKAsyDy5j",
            "bGllbnQuQWRkcmVzcxInChFvcmdhbml6YXRpb25faGFzaBgDIAEoCzIMLmNs",
            "aWVudC5IYXNoEkQKGnByb3Bvc2FsX3JlbGVhc2VfdGhyZXNob2xkGAQgASgL",
            "MiAuY2xpZW50LlByb3Bvc2FsUmVsZWFzZVRocmVzaG9sZBIrCiNwYXJsaWFt",
            "ZW50X21lbWJlcl9wcm9wb3NpbmdfYWxsb3dlZBgFIAEoCBIkCg5jcmVhdGlv",
            "bl90b2tlbhgGIAEoCzIMLmNsaWVudC5IYXNoQh6qAhtBRWxmLkNsaWVudC5B",
            "c3NvY2lhdGlvbkF1dGhiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { global::AElf.Client.Proto.ClientReflection.Descriptor, },
          new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::AElf.Client.AssociationAuth.Organization), global::AElf.Client.AssociationAuth.Organization.Parser, new[]{ "ProposerAuthorityRequired", "OrganizationAddress", "OrganizationHash", "ProposalReleaseThreshold", "ParliamentMemberProposingAllowed", "CreationToken" }, null, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  /// association_auth_contract
  /// </summary>
  [global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
  public sealed partial class Organization : pb::IMessage<Organization>
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      , pb::IBufferMessage
  #endif
  {
    private static readonly pb::MessageParser<Organization> _parser = new pb::MessageParser<Organization>(() => new Organization());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pb::MessageParser<Organization> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::AElf.Client.AssociationAuth.AssociationAuthContractReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Organization() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Organization(Organization other) : this() {
      proposerAuthorityRequired_ = other.proposerAuthorityRequired_;
      organizationAddress_ = other.organizationAddress_ != null ? other.organizationAddress_.Clone() : null;
      organizationHash_ = other.organizationHash_ != null ? other.organizationHash_.Clone() : null;
      proposalReleaseThreshold_ = other.proposalReleaseThreshold_ != null ? other.proposalReleaseThreshold_.Clone() : null;
      parliamentMemberProposingAllowed_ = other.parliamentMemberProposingAllowed_;
      creationToken_ = other.creationToken_ != null ? other.creationToken_.Clone() : null;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public Organization Clone() {
      return new Organization(this);
    }

    /// <summary>Field number for the "proposer_authority_required" field.</summary>
    public const int ProposerAuthorityRequiredFieldNumber = 1;
    private bool proposerAuthorityRequired_;
    /// <summary>
    /// Indicates if proposals need authority to be created.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool ProposerAuthorityRequired {
      get { return proposerAuthorityRequired_; }
      set {
        proposerAuthorityRequired_ = value;
      }
    }

    /// <summary>Field number for the "organization_address" field.</summary>
    public const int OrganizationAddressFieldNumber = 2;
    private global::AElf.Client.Proto.Address organizationAddress_;
    /// <summary>
    /// The organization address.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::AElf.Client.Proto.Address OrganizationAddress {
      get { return organizationAddress_; }
      set {
        organizationAddress_ = value;
      }
    }

    /// <summary>Field number for the "organization_hash" field.</summary>
    public const int OrganizationHashFieldNumber = 3;
    private global::AElf.Client.Proto.Hash organizationHash_;
    /// <summary>
    /// The organization id.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::AElf.Client.Proto.Hash OrganizationHash {
      get { return organizationHash_; }
      set {
        organizationHash_ = value;
      }
    }

    /// <summary>Field number for the "proposal_release_threshold" field.</summary>
    public const int ProposalReleaseThresholdFieldNumber = 4;
    private global::AElf.Client.Proto.ProposalReleaseThreshold proposalReleaseThreshold_;
    /// <summary>
    /// The threshold for releasing the proposal.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::AElf.Client.Proto.ProposalReleaseThreshold ProposalReleaseThreshold {
      get { return proposalReleaseThreshold_; }
      set {
        proposalReleaseThreshold_ = value;
      }
    }

    /// <summary>Field number for the "parliament_member_proposing_allowed" field.</summary>
    public const int ParliamentMemberProposingAllowedFieldNumber = 5;
    private bool parliamentMemberProposingAllowed_;
    /// <summary>
    /// Indicates if parliament member can propose to this organization.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool ParliamentMemberProposingAllowed {
      get { return parliamentMemberProposingAllowed_; }
      set {
        parliamentMemberProposingAllowed_ = value;
      }
    }

    /// <summary>Field number for the "creation_token" field.</summary>
    public const int CreationTokenFieldNumber = 6;
    private global::AElf.Client.Proto.Hash creationToken_;
    /// <summary>
    /// The creation token is for organization address generation.
    /// </summary>
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public global::AElf.Client.Proto.Hash CreationToken {
      get { return creationToken_; }
      set {
        creationToken_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override bool Equals(object other) {
      return Equals(other as Organization);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public bool Equals(Organization other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (ProposerAuthorityRequired != other.ProposerAuthorityRequired) return false;
      if (!object.Equals(OrganizationAddress, other.OrganizationAddress)) return false;
      if (!object.Equals(OrganizationHash, other.OrganizationHash)) return false;
      if (!object.Equals(ProposalReleaseThreshold, other.ProposalReleaseThreshold)) return false;
      if (ParliamentMemberProposingAllowed != other.ParliamentMemberProposingAllowed) return false;
      if (!object.Equals(CreationToken, other.CreationToken)) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override int GetHashCode() {
      int hash = 1;
      if (ProposerAuthorityRequired != false) hash ^= ProposerAuthorityRequired.GetHashCode();
      if (organizationAddress_ != null) hash ^= OrganizationAddress.GetHashCode();
      if (organizationHash_ != null) hash ^= OrganizationHash.GetHashCode();
      if (proposalReleaseThreshold_ != null) hash ^= ProposalReleaseThreshold.GetHashCode();
      if (ParliamentMemberProposingAllowed != false) hash ^= ParliamentMemberProposingAllowed.GetHashCode();
      if (creationToken_ != null) hash ^= CreationToken.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void WriteTo(pb::CodedOutputStream output) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      output.WriteRawMessage(this);
    #else
      if (ProposerAuthorityRequired != false) {
        output.WriteRawTag(8);
        output.WriteBool(ProposerAuthorityRequired);
      }
      if (organizationAddress_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(OrganizationAddress);
      }
      if (organizationHash_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(OrganizationHash);
      }
      if (proposalReleaseThreshold_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(ProposalReleaseThreshold);
      }
      if (ParliamentMemberProposingAllowed != false) {
        output.WriteRawTag(40);
        output.WriteBool(ParliamentMemberProposingAllowed);
      }
      if (creationToken_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(CreationToken);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
      if (ProposerAuthorityRequired != false) {
        output.WriteRawTag(8);
        output.WriteBool(ProposerAuthorityRequired);
      }
      if (organizationAddress_ != null) {
        output.WriteRawTag(18);
        output.WriteMessage(OrganizationAddress);
      }
      if (organizationHash_ != null) {
        output.WriteRawTag(26);
        output.WriteMessage(OrganizationHash);
      }
      if (proposalReleaseThreshold_ != null) {
        output.WriteRawTag(34);
        output.WriteMessage(ProposalReleaseThreshold);
      }
      if (ParliamentMemberProposingAllowed != false) {
        output.WriteRawTag(40);
        output.WriteBool(ParliamentMemberProposingAllowed);
      }
      if (creationToken_ != null) {
        output.WriteRawTag(50);
        output.WriteMessage(CreationToken);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(ref output);
      }
    }
    #endif

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public int CalculateSize() {
      int size = 0;
      if (ProposerAuthorityRequired != false) {
        size += 1 + 1;
      }
      if (organizationAddress_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(OrganizationAddress);
      }
      if (organizationHash_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(OrganizationHash);
      }
      if (proposalReleaseThreshold_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(ProposalReleaseThreshold);
      }
      if (ParliamentMemberProposingAllowed != false) {
        size += 1 + 1;
      }
      if (creationToken_ != null) {
        size += 1 + pb::CodedOutputStream.ComputeMessageSize(CreationToken);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(Organization other) {
      if (other == null) {
        return;
      }
      if (other.ProposerAuthorityRequired != false) {
        ProposerAuthorityRequired = other.ProposerAuthorityRequired;
      }
      if (other.organizationAddress_ != null) {
        if (organizationAddress_ == null) {
          OrganizationAddress = new global::AElf.Client.Proto.Address();
        }
        OrganizationAddress.MergeFrom(other.OrganizationAddress);
      }
      if (other.organizationHash_ != null) {
        if (organizationHash_ == null) {
          OrganizationHash = new global::AElf.Client.Proto.Hash();
        }
        OrganizationHash.MergeFrom(other.OrganizationHash);
      }
      if (other.proposalReleaseThreshold_ != null) {
        if (proposalReleaseThreshold_ == null) {
          ProposalReleaseThreshold = new global::AElf.Client.Proto.ProposalReleaseThreshold();
        }
        ProposalReleaseThreshold.MergeFrom(other.ProposalReleaseThreshold);
      }
      if (other.ParliamentMemberProposingAllowed != false) {
        ParliamentMemberProposingAllowed = other.ParliamentMemberProposingAllowed;
      }
      if (other.creationToken_ != null) {
        if (creationToken_ == null) {
          CreationToken = new global::AElf.Client.Proto.Hash();
        }
        CreationToken.MergeFrom(other.CreationToken);
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    public void MergeFrom(pb::CodedInputStream input) {
    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
      input.ReadRawMessage(this);
    #else
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            ProposerAuthorityRequired = input.ReadBool();
            break;
          }
          case 18: {
            if (organizationAddress_ == null) {
              OrganizationAddress = new global::AElf.Client.Proto.Address();
            }
            input.ReadMessage(OrganizationAddress);
            break;
          }
          case 26: {
            if (organizationHash_ == null) {
              OrganizationHash = new global::AElf.Client.Proto.Hash();
            }
            input.ReadMessage(OrganizationHash);
            break;
          }
          case 34: {
            if (proposalReleaseThreshold_ == null) {
              ProposalReleaseThreshold = new global::AElf.Client.Proto.ProposalReleaseThreshold();
            }
            input.ReadMessage(ProposalReleaseThreshold);
            break;
          }
          case 40: {
            ParliamentMemberProposingAllowed = input.ReadBool();
            break;
          }
          case 50: {
            if (creationToken_ == null) {
              CreationToken = new global::AElf.Client.Proto.Hash();
            }
            input.ReadMessage(CreationToken);
            break;
          }
        }
      }
    #endif
    }

    #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
    void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
      if ((tag & 7) == 4) {
        // Abort on any end group tag.
        return;
      }
      switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
            break;
          case 8: {
            ProposerAuthorityRequired = input.ReadBool();
            break;
          }
          case 18: {
            if (organizationAddress_ == null) {
              OrganizationAddress = new global::AElf.Client.Proto.Address();
            }
            input.ReadMessage(OrganizationAddress);
            break;
          }
          case 26: {
            if (organizationHash_ == null) {
              OrganizationHash = new global::AElf.Client.Proto.Hash();
            }
            input.ReadMessage(OrganizationHash);
            break;
          }
          case 34: {
            if (proposalReleaseThreshold_ == null) {
              ProposalReleaseThreshold = new global::AElf.Client.Proto.ProposalReleaseThreshold();
            }
            input.ReadMessage(ProposalReleaseThreshold);
            break;
          }
          case 40: {
            ParliamentMemberProposingAllowed = input.ReadBool();
            break;
          }
          case 50: {
            if (creationToken_ == null) {
              CreationToken = new global::AElf.Client.Proto.Hash();
            }
            input.ReadMessage(CreationToken);
            break;
          }
        }
      }
    }
    #endif

  }

  #endregion

}

#endregion Designer generated code
