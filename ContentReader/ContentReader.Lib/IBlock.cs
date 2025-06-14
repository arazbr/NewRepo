﻿using System.Collections.Generic;
using System;

namespace SCICT.Microsoft.Office.Word.ContentReader
{
    /// <summary>
    /// The parent interface for the objects carrying MS-Word document content.
    /// </summary>
    [Obsolete("Use RangeWrapper instead!", true)]
    public abstract class IBlock
    {
        /// <summary>
        /// Reference to the document owning this block
        /// </summary>
        private readonly IDocument m_parentDocument = null;

        /// <summary>
        /// Gets a reference to the document owning this block
        /// </summary>
        public IDocument ParentDocument
        {
            get { return m_parentDocument; }
            //set { m_parentDocument = value; }
        }

        /// <summary>
        /// Protected Constructor, sets the reference to the parent document object.
        /// </summary>
        /// <param name="parentDocument"></param>
        protected IBlock(IDocument parentDocument)
        {
            this.m_parentDocument = parentDocument;
        }

        /// <summary>
        /// The main content of the Block.
        /// </summary>
        public abstract string Content { get; }

        /// <summary>
        /// The type of the block, whether it is Paragraph, Sentence, Word, and so on.
        /// </summary>
        public abstract BlockType BlockType
        {
            get;
            //protected set;
        }

        /// <summary>
        /// Where this block is located. It is based upon Range.StoryType
        /// StoryTypes could be FootNote, EndNote, MainText, and so on
        /// </summary>
        public abstract StoryType StoryType
        {
            get;
            //protected set;
        }

        /// <summary>
        /// Sequence of paragraphs within this block
        /// </summary>
        public abstract IEnumerable<IBlock> Paragraphs
        {
            get;
        }

        /// <summary>
        /// Sequence of sentences within this block
        /// </summary>
        public abstract IEnumerable<IBlock> Sentences
        {
            get;
        }

        /// <summary>
        /// Sequence of words within this block
        /// </summary>
        public abstract IEnumerable<IBlock> Words
        {
            get;
        }
    }
}
