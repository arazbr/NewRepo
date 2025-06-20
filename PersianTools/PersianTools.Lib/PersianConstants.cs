﻿// Author: Omid Kashefi, Sina Iravanian, Mehrdad Senobari 
// Created on: 2010-March-08
// Last Modified: Omid Kashefi, Sina Iravanian, Mehrdad Senobari at 2010-March-08
//


using System;
using System.Collections.Generic;
using System.Linq;
using SCICT.NLP.Utility;

namespace SCICT.NLP.Persian.Constants
{
    #region PseudoSpace

    /// <summary>
    /// Holds PseudoSpace related constants
    /// TODO: Complete this class based on unicode spaces, specified here:
    /// http://www.cs.tut.fi/~jkorpela/chars/spaces.html
    /// http://www.alanwood.net/unicode/general_punctuation.html
    /// </summary>
    public static class PseudoSpace
    {
        /// <summary>
        /// The main standard PseudoSpace (Zero Width Non-Joiner)
        /// Value: U+200C
        /// </summary>
        public static readonly char ZWNJ = '\u200C';

        /// <summary>
        /// alternative PseudoSpace (Zero Width Space)
        /// Value: U+200B
        /// </summary>
        public static readonly char ZWS = '\u200B';

        /// <summary>
        /// alternative PseudoSpace (Zero Width Joiner)
        /// Value: U+200D
        /// </summary>
        public static readonly char ZWJ = '\u200D';

        /// <summary>
        /// alternative PseudoSpace used by Microsoft Word (Ctrl + -)
        /// Value: U+00AC
        /// </summary>
        public static readonly char MSWPS = '\u00AC';
    }

    #endregion

    #region He-Ye

    /// <summary>
    /// Holds He-ye related constants
    /// </summary>
    public static class HeYe
    {
        /// <summary>
        /// A single hamza letter which is going to be used as the standard short-from Ye.
        /// </summary>
        public static readonly char ArabicHamzaAbove = '\u0654'; // The *final* char in: هٔ

        /// <summary>
        /// A single character containing both He and Ye in a single glyph.
        /// This is a non-standard character in Persian contexts.
        /// </summary>
        public static readonly char ArabicHeWithYeAbove = '\u06C0'; // ۀ

        /// <summary>
        /// A single character containing both He and Ye in a single glyph. 
        /// This is a non-standard character in Persian contexts.
        /// </summary>
        public static readonly char ArabicHeGoalWithYeAbove = '\u06C2'; // 

        /// <summary>
        /// Arabic Hamzah, which is sometimes used as Yeh following Pseudo-space and Heh
        /// </summary>
        public static readonly char ArabicHamzah = '\u0621';

        /// <summary>
        /// Standard character He
        /// </summary>
        public static readonly char He = 'ه';

        /// <summary>
        /// Standard form of writing long HeYe (i.e., ه‌ی)
        /// </summary>
        public static readonly string StandardLongHeYe = "" + He + Convert.ToChar(StandardCharacters.StandardHalfSpace) +
                                                         Convert.ToChar(StandardCharacters.StandardYaa);

        /// <summary>
        /// Standard form of writing short HeYe (i.e., هٔ)
        /// </summary>
        public static readonly string StandardShortHeYe = "" + He + ArabicHamzaAbove;

        /// <summary>
        /// Determines whether the specified word sequence is forming a long HeYe.
        /// </summary>
        /// <param name="word0">first word</param>
        /// <param name="word1">second word</param>
        /// <returns>
        /// 	<c>true</c> if the specified word sequence is forming a long HeYe; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsTwoWordsFormingLongHeYe(string word0, string word1)
        {
            int lastWord0Index = StringUtil.LastWordCharIndex(word0);
            if(lastWord0Index < 0)
                return false;

            if (word0[lastWord0Index] != HeYe.He)
                return false;

            string nextWordRefined = StringUtil.RefineAndFilterPersianWord(word1);
            
            if (nextWordRefined == Convert.ToChar(StandardCharacters.StandardYaa).ToString())
                return true;
            
            if(nextWordRefined == ArabicHamzah.ToString())
                return true;

            return false;
        }
        
        static HeYe()
        {
            Load();
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        internal static void Load()
        {
            // Nothing to-do now
        }
    }

    #endregion

    #region PersianAlphabet

    /// <summary>
    /// Holds constants related to the persian language
    /// </summary>
    public static class PersianAlphabets
    {
        /// <summary>
        /// The standard tashdid character.
        /// </summary>
        public static readonly char Tashdid = '\u0651';

        /// <summary>
        /// Persian Alphabets
        /// </summary>
        public static string Alphabets
        {
            get
            {
                return ConsonantsInAllConditions + Vowels + Diacritics;
            }
        }

        ///<summary>
        /// Persian Alphabets with Pseudo-space (ZWNJ)
        ///</summary>
        public static string AlphabetWithPseudoSpace
        {
            get
            {
                return Alphabets + PseudoSpace.ZWNJ;
            }
        }

        //public static string AlphabetWithPseudoSpace = "آابپتثجچ‌حخدذرزژسشصضطظعغفقکگلمنوهیئأإؤ";

        /// <summary>
        /// Persian Delimiters
        /// </summary>
        public static readonly string Delimiters = ".,:;`/\"+-_(){}[]<>*&^%$#@!?؟~/|\\ =1234567890«»،٫٬\n\t٠١٢٣٤٥٦٧٨٩٪٭۰۱۲۳۴۵۶۷۸۹﴾﴿۔ـ؛¸·´­¨¬";

        ///<summary>
        /// Numbers
        ///</summary>
        public static readonly string Numbers = "۰۱۲۳۴۵۶۷۸۹";

        ///<summary>
        /// Consonant letters
        ///</summary>
        public static string Consonants
        {
            get
            {
                return ConsonantsInAllConditions + ConsonantsConditional;
            }
        }

        ///<summary>
        /// Consonant letters
        ///</summary>
        public static string ConsonantsInAllConditions
        {
            get
            {
                return ConsonantsNonStickerInAllCondition + ConsonantsStickerInAllCondition;
            }
        }

        ///<summary>
        /// Consonant letters
        ///</summary>
        public static string ConsonantsConditional
        {
            get
            {
                return ConsonantsNonStickerConditional + ConsonantsStickerConditional;
            }
        }

        ///<summary>
        /// Consonant letters
        ///</summary>
        public static string ConsonantsStickers
        {
            get
            {
                return ConsonantsStickerInAllCondition + ConsonantsStickerConditional;
            }
        }

        ///<summary>
        /// Consonant letters
        ///</summary>
        public static string ConsonantsNonStickers
        {
            get
            {
                return ConsonantsNonStickerInAllCondition + ConsonantsNonStickerConditional;
            }
        }

        ///<summary>
        /// Consonant sticker letters
        ///</summary>
        public static readonly string ConsonantsStickerInAllCondition = "بپتثجچحخسشصضطظعغفقکگلمن";

        ///<summary>
        /// Conditional Consonant sticker letters
        ///</summary>
        public static readonly string ConsonantsStickerConditional = "هئ";

        ///<summary>
        /// Consonant non-sticker letters
        ///</summary>
        public static readonly string ConsonantsNonStickerInAllCondition = "دذرزژ";

        ///<summary>
        /// Conditional Consonant non-sticker letters
        ///</summary>
        public static readonly string ConsonantsNonStickerConditional = "و";

        #endregion

        #region Vowels

        ///<summary>
        /// Vowel letters
        ///</summary>
        public static string Vowels
        {
            get
            {
                return VowelsConditional + VowelsInAllCondition;
            }
        }

        ///<summary>
        /// Vowel letters
        ///</summary>
        public static string VowelsInAllCondition
        {
            get
            {
                return VowelsStickerInAllCondition + VowelsNonStickerInAllCondition;
            }
        }
        
        ///<summary>
        /// Vowel letters
        ///</summary>
        public static string VowelsConditional
        {
            get
            {
                return VowelsStickerConditional + VowelsNonStickerConditional;
            }
        }
        
        ///<summary>
        /// Vowel letters
        ///</summary>
        public static string VowelsStickers
        {
            get
            {
                return VowelsStickerInAllCondition + VowelsStickerConditional;
            }
        }
        
        ///<summary>
        /// Vowel letters
        ///</summary>
        public static string VowelsNonStickers
        {
            get
            {
                return VowelsNonStickerInAllCondition + VowelsNonStickerConditional;
            }
        }

        ///<summary>
        /// Vowel sticker letters
        ///</summary>
        public static readonly string VowelsStickerInAllCondition = "ی";

        ///<summary>
        /// Vowel sticker letters
        ///</summary>
        public static readonly string VowelsStickerConditional = "هئ";

        ///<summary>
        /// Vowel non-sticker letters
        ///</summary>
        public static readonly string VowelsNonStickerInAllCondition = "آا";

        ///<summary>
        /// Vowel non-sticker letters
        ///</summary>
        public static readonly string VowelsNonStickerConditional = "ءوأإؤ";

        #endregion

        #region Diacritics

        ///<summary>
        /// Pseudo letters like Shaddah and Fathatan
        ///</summary>
        public static readonly string Diacritics = new string
            (new char[]
            { 
                (char)StandardCharacters.StandardZammatan,
                (char)StandardCharacters.StandardFathatan,
            });//"ًّ";

        #endregion

        #region Erabs

        /// <summary>
        /// Erabs
        /// </summary>
        public static readonly string Erabs = new string
            (new char[]
            {
                (char)StandardCharacters.StandardFatha,
                (char)StandardCharacters.StandardFathatan,
                (char)StandardCharacters.StandardKasra,
                (char)StandardCharacters.StandardKasratan,
                (char)StandardCharacters.StandardSaaken,
                (char)StandardCharacters.StandardTashdid,
                (char)StandardCharacters.StandardZamma,
                (char)StandardCharacters.StandardZammatan,
            });

        #endregion

        /// <summary>
        /// Persian Characters which are always seperate, and cannot stick to a next char
        /// </summary>
        public static readonly char[] NonStickerChars = new char[] { ' ', '\t',
                'ر', 'ز', 'و', 'ژ', 'ا', 'آ', 'د', 'ذ', 'ٱ', 'ؤ', 'إ', 'أ', 'ء' };


        static PersianAlphabets()
        {
            Load();
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        internal static void Load()
        {
            // Nothing to-do now
        }
    }

    ///<summary>
    /// Homophone letters in Persian, homophone words are those that can pronounce the same
    ///</summary>
    public static class PersianHomophoneLetters
    {

        ///<summary>
        /// Zain homophone family
        ///</summary>
        public static char[] ZainFamily = new char[] { 'ز', 'ض', 'ظ', 'ذ' };
        ///<summary>
        /// Seen homophone family
        ///</summary>
        public static char[] SeenFamily = new char[] { 'س', 'ث', 'ص' };
        ///<summary>
        /// Teh homophone family
        ///</summary>
        public static char[] TehFamily = new char[] { 'ت', 'ط' };
        ///<summary>
        /// Ghain homophone family
        ///</summary>
        public static char[] GhainFamily = new char[] { 'ق', 'غ' };
        ///<summary>
        /// Hah homophone family
        ///</summary>
        public static char[] HahFamily = new char[] { 'ه', 'ح' };
        ///<summary>
        /// Alef homophone family
        ///</summary>
        public static char[] AlefFamily = new char[] { 'ا', 'آ' };
        ///<summary>
        /// Hamza homophone family 1
        ///</summary>
        public static char[] HamzaFamily1 = new char[] { 'ئ', 'أ', 'ء', 'إ', 'ا' };
        ///<summary>
        /// Hamza homophone family 2
        ///</summary>
        public static char[] HamzaFamily2 = new char[] { 'ئ', 'ؤ', 'و' };
        ///<summary>
        /// Ya homophone family
        ///</summary>
        public static char[] YaFamily = new char[] { 'ئ', 'ی'};

        ///<summary>
        /// Get all homophone letters
        ///</summary>
        public static char[][] AllHomophones
        {
            get
            {
                var all = new List<char[]>();
                all.Add(ZainFamily);
                all.Add(SeenFamily);
                all.Add(TehFamily);
                all.Add(GhainFamily);
                all.Add(HahFamily);
                all.Add(AlefFamily);
                all.Add(HamzaFamily1);
                all.Add(HamzaFamily2);
                all.Add(YaFamily);

                return all.ToArray();
            }
        }

        ///<summary>
        /// Check if two letters are homophone
        ///</summary>
        ///<param name="c1">c1</param>
        ///<param name="c2">c2</param>
        ///<returns>True if c1 and c2 are homophone</returns>
        public static bool AreHomophone(char c1, char c2)
        {
            foreach(char[] homophoneFamily in AllHomophones)
            {
                if (homophoneFamily.Contains(c1) && homophoneFamily.Contains(c2))
                {
                    return true;
                }
            }

            return false;
        }
    }

    #region PersianHomoshapeLetters

    ///<summary>
    /// Homoshape letters in Persian, homophone words are those that can pronounce the same
    ///</summary>
    public static class PersianHomoshapeLetters
    {

        ///<summary>
        /// Alef homoshape family
        ///</summary>
        public static char[] AlefFamily = new char[] { 'أ', 'إ', 'ا'};
        ///<summary>
        /// Be homoshape family
        ///</summary>
        public static char[] BeFamily = new char[] { 'ب', 'پ' };
        ///<summary>
        /// Teh homoshape family
        ///</summary>
        public static char[] TehFamily = new char[] { 'ت', 'ث' };
        ///<summary>
        /// Hah homoshape family
        ///</summary>
        public static char[] HahFamily = new char[] { 'ح', 'ج', 'چ' };
        ///<summary>
        /// Xah homoshape family
        ///</summary>
        public static char[] XahFamily = new char[] { 'خ', 'ح' };
        ///<summary>
        /// Dal homoshape family
        ///</summary>
        public static char[] DalFamily = new char[] { 'د', 'ذ' };
        ///<summary>
        /// Zeh homoshape family
        ///</summary>
        public static char[] ZehFamily = new char[] { 'ر', 'ز' };
        ///<summary>
        /// Zain homoshape family
        ///</summary>
        public static char[] ZainFamily = new char[] { 'ض', 'ص' };
        ///<summary>
        /// Zath homoshape family
        ///</summary>
        public static char[] ZathFamily = new char[] { 'ظ', 'ط' };
        ///<summary>
        /// Ghain homoshape family
        ///</summary>
        public static char[] GhainFamily = new char[] { 'غ', 'ع' };
        ///<summary>
        /// Kaf homoshape family
        ///</summary>
        public static char[] KafFamily = new char[] { 'گ', 'ک' };
        ///<summary>
        /// Ghaf homoshape family
        ///</summary>
        public static char[] GhafFamily = new char[] { 'ف', 'ق' };

        ///<summary>
        /// Get all homophone letters
        ///</summary>
        public static char[][] AllHomoshapes
        {
            get
            {
                var all = new List<char[]>();
                all.Add(AlefFamily);
                all.Add(BeFamily);
                all.Add(TehFamily);
                all.Add(HahFamily);
                all.Add(XahFamily);
                all.Add(DalFamily);
                all.Add(ZehFamily);
                all.Add(ZainFamily);
                all.Add(ZathFamily);
                all.Add(GhainFamily);
                all.Add(KafFamily);
                all.Add(GhafFamily);

                return all.ToArray();
            }
        }

        ///<summary>
        /// Check if two letters are homoshape
        ///</summary>
        ///<param name="c1">c1</param>
        ///<param name="c2">c2</param>
        ///<returns>True if c1 and c2 are homoshape</returns>
        public static bool AreHomoshape(char c1, char c2)
        {
            foreach (char[] homoshapeFamily in AllHomoshapes)
            {
                if (homoshapeFamily.Contains(c1) && homoshapeFamily.Contains(c2))
                {
                    return true;
                }
            }

            return false;
        }
    }

    #endregion

    #region StandardCharacters

    /// <summary>
    /// Holds constants about Persian standard character codes
    /// </summary>
    public static class StandardCharacters
    {
        #region Loaders
        static StandardCharacters()
        {
            Load();
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        internal static void Load()
        {
            // Nothing to do now
        }
        #endregion

        /// <summary>
        /// The Standard Kaaf letter code in Persian keyboard
        /// </summary>
        public static readonly int StandardKaaf = 0x06A9;

        /// <summary>
        /// The Standard Yaa letter code in Persian keyboard
        /// </summary>
        public static readonly int StandardYaa = 0x06CC;

        /// <summary>
        /// The Standard Digit 0 code in Persian keyboard
        /// </summary>
        public static readonly int StandardDigit0 = 0x06F0;

        /// <summary>
        /// The Standard Digit 1 code in Persian keyboard
        /// </summary>
        public static readonly int StandardDigit1 = 0x06F1;

        /// <summary>
        /// The Standard Digit 2 code in Persian keyboard
        /// </summary>
        public static readonly int StandardDigit2 = 0x06F2;

        /// <summary>
        /// The Standard Digit 3 code in Persian keyboard
        /// </summary>
        public static readonly int StandardDigit3 = 0x06F3;

        /// <summary>
        /// The Standard Digit 4 code in Persian keyboard
        /// </summary>
        public static readonly int StandardDigit4 = 0x06F4;

        /// <summary>
        /// The Standard Digit 5 code in Persian keyboard
        /// </summary>
        public static readonly int StandardDigit5 = 0x06F5;

        /// <summary>
        /// The Standard Digit 6 code in Persian keyboard
        /// </summary>
        public static readonly int StandardDigit6 = 0x06F6;

        /// <summary>
        /// The Standard Digit 7 code in Persian keyboard
        /// </summary>
        public static readonly int StandardDigit7 = 0x06F7;

        /// <summary>
        /// The Standard Digit 8 code in Persian keyboard
        /// </summary>
        public static readonly int StandardDigit8 = 0x06F8;

        /// <summary>
        /// The Standard Digit 9 code in Persian keyboard
        /// </summary>
        public static readonly int StandardDigit9 = 0x06F9;

        /// <summary>
        /// The Standard Half Space code in Persian keyboard: 0x200C
        /// </summary>
        public static readonly int StandardHalfSpace = PseudoSpace.ZWNJ;

        /// <summary>
        /// The Standard Tashdid letter code in Persian keyboard
        /// </summary>
        public static readonly int StandardTashdid = 0x0651;

        /// <summary>
        /// The Standard Fathatan letter code in Persian keyboard
        /// </summary>
        public static readonly int StandardFathatan = 0x064B;

        /// <summary>
        /// The Standard Fatha letter code in Persian keyboard
        /// </summary>
        public static readonly int StandardFatha = 0x064E;

        /// <summary>
        /// The Standard Zamma letter code in Persian keyboard
        /// </summary>
        public static readonly int StandardZamma = 0x064F;

        /// <summary>
        /// The Standard Saaken letter code in Persian keyboard
        /// </summary>
        public static readonly int StandardSaaken = 0x0652;

        /// <summary>
        /// The Standard Zammatan letter code in Persian keyboard
        /// </summary>
        public static readonly int StandardZammatan = 0x064C;

        /// <summary>
        /// The Standard Kasra letter code in Persian keyboard
        /// </summary>
        public static readonly int StandardKasra = 0x0650;

        /// <summary>
        /// The Standard Kasratan letter code in Persian keyboard
        /// </summary>
        public static readonly int StandardKasratan = 0x064D;
    }

    #endregion

    #region Special Characters

    /// <summary>
    /// Character codes which are used by Microsoft Word for special purposes
    /// </summary>
    public static class WordSpecialCharacters
    {
        /// <summary>
        /// Code for the character used to delimit formulas in Word 2003.
        /// </summary>
        public static readonly int FormulaDelimiterCode = 1;

        /// <summary>
        /// Code for the character used to delimit footnotes.
        /// </summary>
        public static readonly int FootnoteDelimiterCode = 2;

        /// <summary>
        /// Character used to delimit formulas in Word 2003
        /// </summary>
        public static readonly char FormulaDelimiter = Convert.ToChar(FormulaDelimiterCode);

        /// <summary>
        /// Replacement String in Persian for the formula special character
        /// </summary>
        public static readonly string FormulaDelimiterReplacementString = "(فرمول)";

        /// <summary>
        /// Replacement RTF-String in Persian for the formula special character
        /// </summary>
        public static readonly string FormulaDelimiterReplacementRTF = @"\lang1065\f1\rtlch(\'dd\'d1\'e3\'e6\'e1)";

        /// <summary>
        /// Character used to delimit footnotes
        /// </summary>
        public static readonly char FootnoteDelimiter = Convert.ToChar(FootnoteDelimiterCode);

        /// <summary>
        /// Replacement String in Persian for the footnote special character
        /// </summary>
        public static readonly string FootnoteDelimiterReplacementString = "(پاورقی)";

        /// <summary>
        /// Replacement RTF-String in Persian for the footnote special character
        /// </summary>
        public static readonly string FootnoteDelimiterReplacementRTF = @"\lang1065\f1\rtlch(\'81\'c7\'e6\'d1\'de\u1740?)";

        /// <summary>
        /// An array of special characters used by Microsoft Word for special purposes.
        /// </summary>
        public static readonly char[] SpecialCharsArray = new char[] { FormulaDelimiter, FootnoteDelimiter };
    }

    #endregion

    #region Punctuations

    ///<summary>
    /// Quotation Marks
    ///</summary>
    public static class QuotationMark
    {
        /// <summary>
        /// ASCII representation of single quotation mark
        /// </summary>
        public static char SingleQuotationMark = '\'';

        ///<summary>
        /// Right quotation mark as seen in printed content
        ///</summary>
        public static char RightSingleQuotationMark = '\u2019';

        ///<summary>
        /// Right quotation mark as seen in printed content
        ///</summary>
        public static char SingleLow9QuotationMark = '\u201A';
        
        ///<summary>
        /// Single Low-9 Quotation Mark
        ///</summary>
        public static char SingleHighReveresed9QuotationMark = '\u201B';

        ///<summary>
        /// Character which is used to show 'prime' in mathematical context.
        ///</summary>
        public static char Prime = '\u2032';
    }

    #endregion

    #region Persian POS Tags

    ///<summary>
    /// Persian Part-of-Speech (POS) tags
    ///</summary>
    [Flags]
    public enum PersianPOSTag
    {
        ///<summary>
        /// Adverb
        ///</summary>
        ADV = 1,
        
        ///<summary>
        /// Adjective
        ///</summary>
        AJ = ADV * 2,
        
        ///<summary>
        /// Measurment Units
        ///</summary>
        CL = AJ * 2,

        ///<summary>
        /// Conjunction
        ///</summary>
        CONJ = CL * 2,

        ///<summary>
        /// Determiner
        ///</summary>
        DET = CONJ * 2,

        ///<summary>
        /// Interjection 
        ///</summary>
        INT = DET * 2,

        ///<summary>
        /// Noun
        ///</summary>
        N = INT * 2,

        ///<summary>
        /// Numbers
        ///</summary>
        NUM = N * 2,

        ///<summary>
        /// Preposition
        ///</summary>
        P = NUM * 2,

        ///<summary>
        /// Postposition 
        ///</summary>
        POSTP = P * 2,

        ///<summary>
        /// Pronoun
        ///</summary>
        PRO = POSTP * 2,

        ///<summary>
        /// Punctuation
        ///</summary>
        PUNC = PRO * 2,

        ///<summary>
        /// Rests, Not recognized
        ///</summary>
        RES = PUNC * 2,

        ///<summary>
        /// Verb
        ///</summary>
        V = RES *2,

        ///<summary>
        /// User aadded words, not yet tagged
        ///</summary>
        UserPOS = V * 2,

        ///<summary>
        /// Ends with a vowel
        ///</summary>
        VowelEnding = UserPOS * 2,

        ///<summary>
        /// Ends with a consonant
        ///</summary>
        ConsonantalEnding = VowelEnding * 2
    }

    #endregion

    #region Persian POS Tags: Hedy

    [Flags]
    public enum PersianPartOfSpeech : ulong 
    {
        Unknown = 0x0,

        Noun = 0x1,
        Adjective = 0x2,
        Adverb = 0x4,
        Verb = 0x8,
        Preposition = 0x10,
        Postposition = 0x20,
        Pronoun = 0x40,
        Determiner = 0x80,
        Conjunction = 0x100,
        Interjunction = 0x200,
        Number = 0x400,
        Classifier = 0x800,
        Punctuation = 0x1000,
        // 0x1FFF

        Singular = 0x2000,
        Plural = 0x4000,
        // 0x6000

        FirstPerson = 0x8000,
        SecondPerson = 0x10000,
        ThirdPerson = 0x20000,
        // 0x38000

        Comparative = 0x40000,
        Superlative = 0x80000,
        // 0xC0000

        Positive = 0x100000,
        Negative = 0x200000,
        // 0x300000

        MAZI_E_SADE = 0x400000,
        MAZI_E_ESTEMRARI = 0x800000,
        MAZI_E_BAEID = 0x1000000,
        MAZI_E_MOSTAMAR = 0x2000000,
        MAZI_E_SADEYE_NAGHLI = 0x4000000,
        MAZI_E_ESTEMRARIE_NAGHLI = 0x8000000,
        MAZI_E_BAEIDE_NAGHLI = 0x10000000,
        MAZI_E_MOSTAMARE_NAGHLI = 0x20000000,
        MAZI_E_ELTEZAMI = 0x40000000,
        MOZARE_E_EKHBARI = 0x80000000,
        MOZARE_E_MOSTAMAR = 0x100000000,
        MOZARE_E_ELTEZAMI = 0x200000000,
        AYANDE = 0x40000000,
        AMR = 0x80000000
        // 0xFFFC00000

    }
    #endregion

    #region Persian Suffixes

    public static class PersianSuffixes
    {
        public static string[] ObjectivePronounsBase = new string[] { "مان", "تان", "شان", "ش", "ت", "م" };
        public static string[] ObjectivePronounsPermutedForHaaYaa = new string[] { "مان", "تان", "شان", "اش", "ات", "ام" };
        public static string[] ObjectivePronounsPermutedForAlef = new string[] { "یمان", "یتان", "یشان", "یش", "یت", "یم" };
        public static string[] ObjectivePronouns
        {
            get
            {
                List<string> tmpList = new List<string>();
                
                tmpList.AddRange(ObjectivePronounsBase);
                tmpList.AddRange(ObjectivePronounsPermutedForHaaYaa);
                tmpList.AddRange(ObjectivePronounsPermutedForAlef);
                
                return tmpList.ToArray();
            }
        }

        public static string[] ToBeVerbsBase = new string[] { "یم", "ید", "ند", "ی", "م", "ست" };
        public static string[] ToBeVerbsPermutedForHaaYaa = new string[] { "ایم", "اید", "اند", "ای", "ام" /*, "است" */};
        public static string[] ToBeVerbsPermutedForAlef = new string[] { "ییم", "یید", "یند", "یی", "یم", "ست" };
        public static string[] ToBeVerbs
        {
            get
            {
                List<string> tmpList = new List<string>();

                tmpList.AddRange(ToBeVerbsBase);
                tmpList.AddRange(ToBeVerbsPermutedForHaaYaa);
                tmpList.AddRange(ToBeVerbsPermutedForAlef);

                return tmpList.ToArray();
            }
        }

        public static string[] IndefiniteYaaBase = new string[] { "ی" };
        public static string[] IndefiniteYaaPermutedForHaaYaa = new string[] { "ای" };
        public static string[] IndefiniteYaaPermutedForAlef = new string[] { "یی" };
        public static string[] IndefiniteYaa
        {
            get
            {
                List<string> tmpList = new List<string>();

                tmpList.AddRange(IndefiniteYaaBase);
                tmpList.AddRange(IndefiniteYaaPermutedForHaaYaa);
                tmpList.AddRange(IndefiniteYaaPermutedForAlef);

                return tmpList.ToArray();
            }
        }

        public static string[] YaaBadalAzKasre = new string[] { "ی" };

        public static string[] YaaNesbatBase = new string[] { "ی" };
        public static string[] YaaNesbatPermutedForHaaYaa = new string[] { "ای" };
        public static string[] YaaNesbatPermutedForAlef = new string[] { "یی" };
        public static string[] YaaNesbat
        {
            get
            {
                var tmpList = new List<string>();

                tmpList.AddRange(YaaNesbatBase);
                tmpList.AddRange(YaaNesbatPermutedForHaaYaa);
                tmpList.AddRange(YaaNesbatPermutedForAlef);

                return tmpList.ToArray();
            }
        }

        public static string[] EnumerableAdjectiveAmbigus = new string[] { "گانه" };
        public static string[] EnumerableAdjectiveOrdinal = new string[] { "مین", "م" };
        public static string[] EnumerableAdjective
        {
            get
            {
                var tmpList = new List<string>();

                tmpList.AddRange(EnumerableAdjectiveAmbigus);
                tmpList.AddRange(EnumerableAdjectiveOrdinal);

                return tmpList.ToArray();
            }
        }

        public static string[] ComparativeAdjectives = new string[] { "تر", "ترین" };

        public static string[] PluralSignHaa = new string[] { "ها" };

        public static string[] PluralSignAanBase = new string[] { "ان" };
        public static string[] PluralSignAanPermutedForHaa = new string[] { "گان" };
        public static string[] PluralSignAanPermutedForAlef = new string[] { "یان" };
        public static string[] PluralSignAan
        {
            get
            {
                List<string> tmpList = new List<string>();

                tmpList.AddRange(PluralSignAanBase);
                tmpList.AddRange(PluralSignAanPermutedForHaa);
                tmpList.AddRange(PluralSignAanPermutedForAlef);

                return tmpList.ToArray();
            }
        }

    }

    public static class PersianColloqualSuffixes
    {
        public static string[] ObjectivePronouns = new string[] { "شون", "مون", "تون", "ش", "ت", "م" };
        public static string[] ToBeVerbs = new string[] { "یم", "م", "ی", "ه", "ین", "ن" };
    }

    [Flags]
    public enum PersianSuffixesCategory
    {
        ObjectivePronoun = 1,
        ToBeVerb = ObjectivePronoun * 2,
        IndefiniteYaa = ToBeVerb * 2,
        YaaBadalAzKasre = IndefiniteYaa * 2,
        YaaNesbat = YaaBadalAzKasre * 2,
        OrdinalEnumerableAdjective = YaaNesbat * 2,
        ComparativeAdjectives = OrdinalEnumerableAdjective * 2,
        PluralSignHaa = ComparativeAdjectives * 2,
        PluralSignAan = PluralSignHaa * 2
    }
    
    #endregion

    #region Persian Combination State

    ///<summary>
    /// The state of combination spacing of two Persian words
    ///</summary>
    public enum PersianCombinationSpacingState
    {
        ///<summary>
        /// Combine with Pseudo-space
        ///</summary>
        PseudoSpace = 1,
        ///<summary>
        /// Combine seprately by a white space
        ///</summary>
        WhiteSpace = PseudoSpace + 1,
        ///<summary>
        /// Combine with no space and make a word
        ///</summary>
        Continous = WhiteSpace + 1
    }

    #endregion
}
