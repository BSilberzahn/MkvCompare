﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NEbml.Core;

namespace MkvCompare
{
    class MatroskaElementDescriptorProvider : DefaultElementDescriptorProvider
    {
        public MatroskaElementDescriptorProvider()
            : base(ElementDescriptors)
        {
        }

        public static readonly ElementDescriptor Segment = new ElementDescriptor(0x18538067, "Segment", ElementType.MasterElement);
        public static readonly ElementDescriptor SegmentInfo = new ElementDescriptor(0x1549a966, "Info", ElementType.MasterElement);
        public static readonly ElementDescriptor Title = new ElementDescriptor(0x7ba9, "Title", ElementType.Utf8String);
        public static readonly ElementDescriptor MuxingApp = new ElementDescriptor(0x4d80, "MuxingApp", ElementType.Utf8String);
        public static readonly ElementDescriptor WritingApp = new ElementDescriptor(0x5741, "WritingApp", ElementType.Utf8String);
        public static readonly ElementDescriptor Duration = new ElementDescriptor(0x4489, "Duration", ElementType.Float);
        public static readonly ElementDescriptor DateUTC = new ElementDescriptor(0x4461, "DateUTC", ElementType.Date);

        private static readonly ElementDescriptor[] ElementDescriptors = 
		{
			Segment,

			new ElementDescriptor(0x114d9b74, "SeekHead", ElementType.MasterElement),
			new ElementDescriptor(0x4dbb, "Seek", ElementType.MasterElement),
			new ElementDescriptor(0x53ab, "SeekID", ElementType.Binary),
			new ElementDescriptor(0x53ac, "SeekPosition", ElementType.UnsignedInteger),

			SegmentInfo,
			new ElementDescriptor(0x73a4, "SegmentUID", ElementType.Binary),
			new ElementDescriptor(0x7384, "SegmentFilename", ElementType.Utf8String),
			new ElementDescriptor(0x3cb923, "PrevUID", ElementType.Binary),
			new ElementDescriptor(0x3c83ab, "PrevFilename", ElementType.Utf8String),
			new ElementDescriptor(0x3eb923, "NextUID", ElementType.Binary),
			new ElementDescriptor(0x3e83bb, "NextFilename", ElementType.Utf8String),
			new ElementDescriptor(0x4444, "SegmentFamily", ElementType.Binary),
			new ElementDescriptor(0x6924, "ChapterTranslate", ElementType.MasterElement),
			new ElementDescriptor(0x69fc, "ChapterTranslateEditionUID", ElementType.UnsignedInteger),
			new ElementDescriptor(0x69bf, "ChapterTranslateCodec", ElementType.UnsignedInteger),
			new ElementDescriptor(0x69a5, "ChapterTranslateID", ElementType.Binary),
			new ElementDescriptor(0x2ad7b1, "TimecodeScale", ElementType.UnsignedInteger),
			Duration,
			DateUTC,
			Title,
			MuxingApp,
			WritingApp,

			new ElementDescriptor(0x1f43b675, "Cluster", ElementType.MasterElement),
			new ElementDescriptor(0xe7, "Timecode", ElementType.UnsignedInteger),
			new ElementDescriptor(0x5854, "SilentTracks", ElementType.MasterElement),
			new ElementDescriptor(0x58d7, "SilentTrackNumber", ElementType.UnsignedInteger),
			new ElementDescriptor(0xa7, "Position", ElementType.UnsignedInteger),
			new ElementDescriptor(0xab, "PrevSize", ElementType.UnsignedInteger),
			new ElementDescriptor(0xa0, "BlockGroup", ElementType.MasterElement),
			new ElementDescriptor(0xa1, "Block", ElementType.Binary),
			new ElementDescriptor(0xa2, "BlockVirtual", ElementType.Binary),
			new ElementDescriptor(0x75a1, "BlockAdditions", ElementType.MasterElement),
			new ElementDescriptor(0xa6, "BlockMore", ElementType.MasterElement),
			new ElementDescriptor(0xee, "BlockAddID", ElementType.UnsignedInteger),
			new ElementDescriptor(0xa5, "BlockAdditional", ElementType.Binary),
			new ElementDescriptor(0x9b, "BlockDuration", ElementType.UnsignedInteger),
			new ElementDescriptor(0xfa, "ReferencePriority", ElementType.UnsignedInteger),
			new ElementDescriptor(0xfb, "ReferenceBlock", ElementType.SignedInteger),
			new ElementDescriptor(0xfd, "ReferenceVirtual", ElementType.SignedInteger),
			new ElementDescriptor(0xa4, "CodecState", ElementType.Binary),
			new ElementDescriptor(0x8e, "Slices", ElementType.MasterElement),
			new ElementDescriptor(0xe8, "TimeSlice", ElementType.MasterElement),
			new ElementDescriptor(0xcc, "LaceNumber", ElementType.UnsignedInteger),
			new ElementDescriptor(0xcd, "FrameNumber", ElementType.UnsignedInteger),
			new ElementDescriptor(0xcb, "BlockAdditionID", ElementType.UnsignedInteger),
			new ElementDescriptor(0xce, "Delay", ElementType.UnsignedInteger),
			new ElementDescriptor(0xcf, "Duration", ElementType.UnsignedInteger),
			new ElementDescriptor(0xa3, "SimpleBlock", ElementType.Binary),
			new ElementDescriptor(0xaf, "EncryptedBlock", ElementType.Binary),

			new ElementDescriptor(0x1654ae6b, "Tracks", ElementType.MasterElement),
			new ElementDescriptor(0xae, "TrackEntry", ElementType.MasterElement),
			new ElementDescriptor(0xd7, "TrackNumber", ElementType.UnsignedInteger),
			new ElementDescriptor(0x73c5, "TrackUID", ElementType.UnsignedInteger),
			new ElementDescriptor(0x83, "TrackType", ElementType.UnsignedInteger),
			new ElementDescriptor(0xb9, "FlagEnabled", ElementType.UnsignedInteger),
			new ElementDescriptor(0x88, "FlagDefault", ElementType.UnsignedInteger),
			new ElementDescriptor(0x55aa, "FlagForced", ElementType.UnsignedInteger),
			new ElementDescriptor(0x9c, "FlagLacing ", ElementType.UnsignedInteger),
			new ElementDescriptor(0x6de7, "MinCache", ElementType.UnsignedInteger),
			new ElementDescriptor(0x6df8, "MaxCache", ElementType.UnsignedInteger),
			new ElementDescriptor(0x23e383, "DefaultDuration", ElementType.UnsignedInteger),
			new ElementDescriptor(0x23314f, "TrackTimecodeScale", ElementType.Float),
			new ElementDescriptor(0x537f, "TrackOffset", ElementType.SignedInteger),
			new ElementDescriptor(0x55ee, "MaxBlockAdditionID", ElementType.UnsignedInteger),
			new ElementDescriptor(0x536e, "Name", ElementType.Utf8String),
			new ElementDescriptor(0x22b59c, "Language", ElementType.AsciiString),
			new ElementDescriptor(0x86, "CodecID", ElementType.AsciiString),
			new ElementDescriptor(0x63a2, "CodecPrivate", ElementType.Binary),
			new ElementDescriptor(0x258688, "CodecName", ElementType.Utf8String),
			new ElementDescriptor(0x7446, "AttachmentLink", ElementType.UnsignedInteger),
			new ElementDescriptor(0x3a9697, "CodecSettings", ElementType.Utf8String),
			new ElementDescriptor(0x3b4040, "CodecInfoURL", ElementType.AsciiString),
			new ElementDescriptor(0x26b240, "CodecDownloadURL", ElementType.AsciiString),
			new ElementDescriptor(0xaa, "CodecDecodeAll", ElementType.UnsignedInteger),
			new ElementDescriptor(0x6fab, "TrackOverlay", ElementType.UnsignedInteger),
			new ElementDescriptor(0x6624, "TrackTranslate", ElementType.MasterElement),
			new ElementDescriptor(0x66fc, "TrackTranslateEditionUID", ElementType.UnsignedInteger),
			new ElementDescriptor(0x66bf, "TrackTranslateCodec", ElementType.UnsignedInteger),
			new ElementDescriptor(0x66a5, "TrackTranslateTrackID", ElementType.Binary),

			new ElementDescriptor(0xe0, "Video", ElementType.MasterElement),
			new ElementDescriptor(0x9a, "FlagInterlaced", ElementType.UnsignedInteger),
			new ElementDescriptor(0x53b8, "StereoMode", ElementType.UnsignedInteger),
			new ElementDescriptor(0xb0, "PixelWidth", ElementType.UnsignedInteger),
			new ElementDescriptor(0xba, "PixelHeight", ElementType.UnsignedInteger),
			new ElementDescriptor(0x54aa, "PixelCropBottom", ElementType.UnsignedInteger),
			new ElementDescriptor(0x54bb, "PixelCropTop", ElementType.UnsignedInteger),
			new ElementDescriptor(0x54cc, "PixelCropLeft", ElementType.UnsignedInteger),
			new ElementDescriptor(0x54dd, "PixelCropRight", ElementType.UnsignedInteger),
			new ElementDescriptor(0x54b0, "DisplayWidth", ElementType.UnsignedInteger),
			new ElementDescriptor(0x54ba, "DisplayHeight", ElementType.UnsignedInteger),
			new ElementDescriptor(0x54b2, "DisplayUnit", ElementType.UnsignedInteger),
			new ElementDescriptor(0x54b3, "AspectRatioType", ElementType.UnsignedInteger),
			new ElementDescriptor(0x2eb524, "ColourSpace", ElementType.Binary),
			new ElementDescriptor(0x2fb523, "GammaValue", ElementType.Float),

			new ElementDescriptor(0xe1, "Audio", ElementType.MasterElement),
			new ElementDescriptor(0xb5, "SamplingFrequency", ElementType.Float),
			new ElementDescriptor(0x78b5, "OutputSamplingFrequency", ElementType.Float),
			new ElementDescriptor(0x9f, "Channels", ElementType.UnsignedInteger),
			new ElementDescriptor(0x7d7b, "ChannelPositions", ElementType.Binary),
			new ElementDescriptor(0x6264, "BitDepth", ElementType.UnsignedInteger),

			new ElementDescriptor(0x6d80, "ContentEncodings", ElementType.MasterElement),
			new ElementDescriptor(0x6240, "ContentEncoding", ElementType.MasterElement),
			new ElementDescriptor(0x5031, "ContentEncodingOrder", ElementType.UnsignedInteger),
			new ElementDescriptor(0x5032, "ContentEncodingScope", ElementType.UnsignedInteger),
			new ElementDescriptor(0x5033, "ContentEncodingType", ElementType.UnsignedInteger),
			new ElementDescriptor(0x5034, "ContentCompression", ElementType.MasterElement),
			new ElementDescriptor(0x4254, "ContentCompAlgo", ElementType.UnsignedInteger),
			new ElementDescriptor(0x4255, "ContentCompSettings", ElementType.Binary),
			new ElementDescriptor(0x5035, "ContentEncryption", ElementType.MasterElement),
			new ElementDescriptor(0x47e1, "ContentEncAlgo", ElementType.UnsignedInteger),
			new ElementDescriptor(0x47e2, "ContentEncKeyID", ElementType.Binary),
			new ElementDescriptor(0x47e3, "ContentSignature", ElementType.Binary),
			new ElementDescriptor(0x47e4, "ContentSigKeyID", ElementType.Binary),
			new ElementDescriptor(0x47e5, "ContentSigAlgo", ElementType.UnsignedInteger),
			new ElementDescriptor(0x47e6, "ContentSigHashAlgo", ElementType.UnsignedInteger),

			new ElementDescriptor(0x1c53bb6b, "Cues", ElementType.MasterElement),
			new ElementDescriptor(0xbb, "CuePoint", ElementType.MasterElement),
			new ElementDescriptor(0xb3, "CueTime", ElementType.UnsignedInteger),
			new ElementDescriptor(0xb7, "CueTrackPositions", ElementType.MasterElement),
			new ElementDescriptor(0xf7, "CueTrack", ElementType.UnsignedInteger),
			new ElementDescriptor(0xf1, "CueClusterPosition", ElementType.UnsignedInteger),
			new ElementDescriptor(0x5378, "CueBlockNumber", ElementType.UnsignedInteger),
			new ElementDescriptor(0xea, "CueCodecState", ElementType.UnsignedInteger),
			new ElementDescriptor(0xdb, "CueReference", ElementType.MasterElement),
			new ElementDescriptor(0x96, "CueRefTime", ElementType.UnsignedInteger),
			new ElementDescriptor(0x97, "CueRefCluster", ElementType.UnsignedInteger),
			new ElementDescriptor(0x535f, "CueRefNumber", ElementType.UnsignedInteger),
			new ElementDescriptor(0xeb, "CueRefCodecState", ElementType.UnsignedInteger),

			new ElementDescriptor(0x1941a469, "Attachments", ElementType.MasterElement),
			new ElementDescriptor(0x61a7, "AttachedFile", ElementType.MasterElement),
			new ElementDescriptor(0x467e, "FileDescription", ElementType.Utf8String),
			new ElementDescriptor(0x466e, "FileName", ElementType.Utf8String),
			new ElementDescriptor(0x4660, "FileMimeType", ElementType.AsciiString),
			new ElementDescriptor(0x465c, "FileData", ElementType.Binary),
			new ElementDescriptor(0x46ae, "FileUID", ElementType.UnsignedInteger),
			new ElementDescriptor(0x4675, "FileReferral", ElementType.Binary),

			new ElementDescriptor(0x1043a770, "Chapters", ElementType.MasterElement),
			new ElementDescriptor(0x45b9, "EditionEntry", ElementType.MasterElement),
			new ElementDescriptor(0x45bc, "EditionUID", ElementType.UnsignedInteger),
			new ElementDescriptor(0x45bd, "EditionFlagHidden", ElementType.UnsignedInteger),
			new ElementDescriptor(0x45db, "EditionFlagDefault", ElementType.UnsignedInteger),
			new ElementDescriptor(0x45dd, "EditionFlagOrdered", ElementType.UnsignedInteger),
			new ElementDescriptor(0xb6, "ChapterAtom", ElementType.MasterElement),
			new ElementDescriptor(0x73c4, "ChapterUID", ElementType.UnsignedInteger),
			new ElementDescriptor(0x91, "ChapterTimeStart", ElementType.UnsignedInteger),
			new ElementDescriptor(0x92, "ChapterTimeEnd", ElementType.UnsignedInteger),
			new ElementDescriptor(0x98, "ChapterFlagHidden", ElementType.UnsignedInteger),
			new ElementDescriptor(0x4598, "ChapterFlagEnabled", ElementType.UnsignedInteger),
			new ElementDescriptor(0x6e67, "ChapterSegmentUID", ElementType.Binary),
			new ElementDescriptor(0x6ebc, "ChapterSegmentEditionUID", ElementType.Binary),
			new ElementDescriptor(0x63c3, "ChapterPhysicalEquiv", ElementType.UnsignedInteger),
			new ElementDescriptor(0x8f, "ChapterTrack", ElementType.MasterElement),
			new ElementDescriptor(0x89, "ChapterTrackNumber", ElementType.UnsignedInteger),
			new ElementDescriptor(0x80, "ChapterDisplay", ElementType.MasterElement),
			new ElementDescriptor(0x85, "ChapString", ElementType.Utf8String),
			new ElementDescriptor(0x437c, "ChapLanguage", ElementType.AsciiString),
			new ElementDescriptor(0x437e, "ChapCountry", ElementType.AsciiString),
			new ElementDescriptor(0x6944, "ChapProcess", ElementType.MasterElement),
			new ElementDescriptor(0x6955, "ChapProcessCodecID", ElementType.UnsignedInteger),
			new ElementDescriptor(0x450d, "ChapProcessPrivate", ElementType.Binary),
			new ElementDescriptor(0x6911, "ChapProcessCommand", ElementType.MasterElement),
			new ElementDescriptor(0x6922, "ChapProcessTime", ElementType.UnsignedInteger),
			new ElementDescriptor(0x6933, "ChapProcessData", ElementType.Binary),

			new ElementDescriptor(0x1254c367, "Tags", ElementType.MasterElement),
			new ElementDescriptor(0x7373, "Tag", ElementType.MasterElement),
			new ElementDescriptor(0x63c0, "Targets", ElementType.MasterElement),
			new ElementDescriptor(0x68ca, "TargetTypeValue", ElementType.UnsignedInteger),
			new ElementDescriptor(0x63ca, "TargetType", ElementType.AsciiString),
			new ElementDescriptor(0x63c5, "TrackUID", ElementType.UnsignedInteger),
			new ElementDescriptor(0x63c9, "EditionUID", ElementType.UnsignedInteger),
			new ElementDescriptor(0x63c4, "ChapterUID", ElementType.UnsignedInteger),
			new ElementDescriptor(0x63c6, "AttachmentUID", ElementType.UnsignedInteger),
			new ElementDescriptor(0x67c8, "SimpleTag", ElementType.MasterElement),
			new ElementDescriptor(0x45a3, "TagName", ElementType.Utf8String),
			new ElementDescriptor(0x447a, "TagLanguage", ElementType.AsciiString),
			new ElementDescriptor(0x4484, "TagDefault", ElementType.UnsignedInteger),
			new ElementDescriptor(0x4487, "TagString", ElementType.Utf8String),
			new ElementDescriptor(0x4485, "TagBinary", ElementType.Binary),
		};

    }
    internal static class ReaderExtensions
    {
        public static bool LocateElement(this EbmlReader reader, ElementDescriptor descriptor)
        {
            while (reader.ReadNext())
            {
                var identifier = reader.ElementId;

                if (identifier == descriptor.Identifier)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
