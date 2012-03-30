// ============================================================================
// <copyright file="DataCollections.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Extracting
{
    using System.Collections.Generic;

    /// <summary>
    /// Represents operating system info.
    /// </summary>
    public class OperatingSystemInfo
    {
        public string Family { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }

    /// <summary>
    /// Represents browser info class.
    /// </summary>
    public class BrowserInfo
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public string ProductPage { get; set; }
        public string LayoutEngine { get; set; }
        public string Description { get; set; }
        public List<string> UserAgents { get; set; }

    }

    /// <summary>
    /// Stop words handler.
    /// </summary>
    public class DataCollections
    {
        #region StopWords

        public static string[] StopWords = new [] {

															  "a", 																													  
															  "about", 
															  "above", 
															  "across", 
															  "afore", 
															  "aforesaid", 
															  "after", 
															  "again", 
															  "against", 
															  "agin", 
															  "ago", 
															  "aint", 
															  "albeit", 
															  "all", 
															  "almost", 
															  "alone", 
															  "along", 
															  "alongside", 
															  "already", 
															  "also", 
															  "although", 
															  "always", 
															  "am", 
															  "american", 
															  "amid", 
															  "amidst", 
															  "among", 
															  "amongst", 
															  "an", 
															  "and", 
															  "anent", 
															  "another", 
															  "any", 
															  "anybody", 
															  "anyone", 
															  "anything", 
															  "are", 
															  "aren't", 
															  "around", 
															  "as", 
															  "aslant", 
															  "astride", 
															  "at", 
															  "athwart", 
															  "away", 
															  "b", 
															  "back", 
															  "bar", 
															  "barring", 
															  "be", 
															  "because", 
															  "been", 
															  "before", 
															  "behind", 
															  "being", 
															  "below", 
															  "beneath", 
															  "beside", 
															  "besides", 
															  "best", 
															  "better", 
															  "between", 
															  "betwixt", 
															  "beyond", 
															  "both", 
															  "but", 
															  "by", 
															  "c", 
															  "can", 
															  "cannot", 
															  "can't", 
															  "certain", 
															  "circa", 
															  "close", 
															  "concerning", 
															  "considering", 
															  "cos", 
															  "could", 
															  "couldn't", 
															  "couldst", 
															  "d", 
															  "dare", 
															  "dared", 
															  "daren't", 
															  "dares", 
															  "daring", 
															  "despite", 
															  "did", 
															  "didn't", 
															  "different", 
															  "directly", 
															  "do", 
															  "does", 
															  "doesn't", 
															  "doing", 
															  "done", 
															  "don't", 
															  "dost", 
															  "doth", 
															  "down", 
															  "during", 
															  "durst", 
															  "e", 
															  "each", 
															  "early", 
															  "either", 
															  "em", 
															  "english", 
															  "enough", 
															  "ere", 
															  "even", 
															  "ever", 
															  "every", 
															  "everybody", 
															  "everyone", 
															  "everything", 
															  "except", 
															  "excepting", 
															  "f", 
															  "failing", 
															  "far", 
															  "few", 
															  "first", 
															  "five", 
															  "following", 
															  "for", 
															  "four", 
															  "from", 
															  "g", 
															  "gonna", 
															  "gotta", 
															  "h", 
															  "had", 
															  "hadn't", 
															  "hard", 
															  "has", 
															  "hasn't", 
															  "hast", 
															  "hath", 
															  "have", 
															  "haven't", 
															  "having", 
															  "he", 
															  "he'd", 
															  "he'll", 
															  "her", 
															  "here", 
															  "here's", 
															  "hers", 
															  "herself", 
															  "he's", 
															  "high", 
															  "him", 
															  "himself", 
															  "his", 
															  "home", 
															  "how", 
															  "howbeit", 
															  "however", 
															  "how's", 
															  "i", 
															  "id", 
															  "if", 
															  "ill", 
															  "i'm", 
															  "immediately", 
															  "important", 
															  "in", 
															  "inside", 
															  "instantly", 
															  "into", 
															  "is", 
															  "isn't", 
															  "it", 
															  "it'll", 
															  "it's", 
															  "its", 
															  "itself", 
															  "i've", 
															  "j", 
															  "just", 
															  "k", 
															  "l", 
															  "large", 
															  "last", 
															  "later", 
															  "least", 
															  "left", 
															  "less", 
															  "lest", 
															  "let's", 
															  "like", 
															  "likewise", 
															  "little", 
															  "living", 
															  "long", 
															  "m", 
															  "many", 
															  "may", 
															  "mayn't", 
															  "me", 
															  "mid", 
															  "midst", 
															  "might", 
															  "mightn't", 
															  "mine", 
															  "minus", 
															  "more", 
															  "most", 
															  "much", 
															  "must", 
															  "mustn't", 
															  "my", 
															  "myself", 
															  "n", 
															  "near", 
															  "'neath", 
															  "need", 
															  "needed", 
															  "needing", 
															  "needn't", 
															  "needs", 
															  "neither", 
															  "never", 
															  "nevertheless", 
															  "new", 
															  "next", 
															  "nigh", 
															  "nigher", 
															  "nighest", 
															  "nisi", 
															  "no", 
															  "no-one", 
															  "nobody", 
															  "none", 
															  "nor", 
															  "not", 
															  "nothing", 
															  "notwithstanding", 
															  "now", 
															  "o", 
															  "o'er", 
															  "of", 
															  "off", 
															  "often", 
															  "on", 
															  "once", 
															  "one", 
															  "oneself", 
															  "only", 
															  "onto", 
															  "open", 
															  "or", 
															  "other", 
															  "otherwise", 
															  "ought", 
															  "oughtn't", 
															  "our", 
															  "ours", 
															  "ourselves", 
															  "out", 
															  "outside", 
															  "over", 
															  "own", 
															  "p", 
															  "past", 
															  "pending", 
															  "per", 
															  "perhaps", 
															  "plus", 
															  "possible", 
															  "present", 
															  "probably", 
															  "provided", 
															  "providing", 
															  "public", 
															  "q", 
															  "qua", 
															  "quite", 
															  "r", 
															  "rather", 
															  "re", 
															  "real", 
															  "really", 
															  "respecting", 
															  "right", 
															  "round", 
															  "s", 
															  "same", 
															  "sans", 
															  "save", 
															  "saving", 
															  "second", 
															  "several", 
															  "shall", 
															  "shalt", 
															  "shan't", 
															  "she", 
															  "shed", 
															  "shell", 
															  "she's", 
															  "short", 
															  "should", 
															  "shouldn't", 
															  "since", 
															  "six", 
															  "small", 
															  "so", 
															  "some", 
															  "somebody", 
															  "someone", 
															  "something", 
															  "sometimes", 
															  "soon", 
															  "special", 
															  "still", 
															  "such", 
															  "summat", 
															  "supposing", 
															  "sure", 
															  "t", 
															  "than", 
															  "that", 
															  "that'd", 
															  "that'll", 
															  "that's", 
															  "the", 
															  "thee", 
															  "their", 
															  "theirs", 
															  "their's", 
															  "them", 
															  "themselves", 
															  "then", 
															  "there", 
															  "there's", 
															  "these", 
															  "they", 
															  "they'd", 
															  "they'll", 
															  "they're", 
															  "they've", 
															  "thine", 
															  "this", 
															  "tho", 
															  "those", 
															  "thou", 
															  "though", 
															  "three", 
															  "thro'", 
															  "through", 
															  "throughout", 
															  "thru", 
															  "thyself", 
															  "till", 
															  "to", 
															  "today", 
															  "together", 
															  "too", 
															  "touching", 
															  "toward", 
															  "towards", 
															  "true", 
															  "'twas", 
															  "'tween", 
															  "'twere", 
															  "'twill", 
															  "'twixt", 
															  "two", 
															  "'twould", 
															  "u", 
															  "under", 
															  "underneath", 
															  "unless", 
															  "unlike", 
															  "until", 
															  "unto", 
															  "up", 
															  "upon", 
															  "us", 
															  "used", 
															  "usually", 
															  "v", 
															  "versus", 
															  "very", 
															  "via", 
															  "vice", 
															  "vis-a-vis", 
															  "w", 
															  "wanna", 
															  "wanting", 
															  "was", 
															  "wasn't", 
															  "way", 
															  "we", 
															  "we'd", 
															  "well", 
															  "were", 
															  "weren't", 
															  "wert", 
															  "we've", 
															  "what", 
															  "whatever", 
															  "what'll", 
															  "what's", 
															  "when", 
															  "whencesoever", 
															  "whenever", 
															  "when's", 
															  "whereas", 
															  "where's", 
															  "whether", 
															  "which", 
															  "whichever", 
															  "whichsoever", 
															  "while", 
															  "whilst", 
															  "who", 
															  "who'd", 
															  "whoever", 
															  "whole", 
															  "who'll", 
															  "whom", 
															  "whore", 
															  "who's", 
															  "whose", 
															  "whoso", 
															  "whosoever", 
															  "will", 
															  "with", 
															  "within", 
															  "without", 
															  "wont", 
															  "would", 
															  "wouldn't", 
															  "wouldst", 
															  "x", 
															  "y", 
															  "ye", 
															  "yet", 
															  "you", 
															  "you'd", 
															  "you'll", 
															  "your", 
															  "you're", 
															  "yours", 
															  "yourself", 
															  "yourselves", 
															  "you've", 
															  "z", 
		};
        #endregion

        /// <summary>
        /// Returns a list of operation systems.
        /// </summary>
        /// <see cref="http://user-agent-string.info/list-of-ua/os"/>
        /// <returns>List of operation systems</returns>
        public static List<OperatingSystemInfo> GetOperatingSystems()
        {
            List<OperatingSystemInfo> os = new List<OperatingSystemInfo>();
            os.Add(new OperatingSystemInfo { Family = "AIX", Name = "AIX", Url = "http://www.ibm.com/aix/", Vendor = "IBM Corporation", Description = "AIX (Advanced Interactive eXecutive) is the name given to a series of proprietary operating systems sold by IBM" });
            os.Add(new OperatingSystemInfo { Family = "Amiga OS", Name = "Amiga OS", Url = "http://www.amiga.com/amigaos/", Vendor = "Amiga, Inc.", Description = "AmigaOS is the default native operating system of the Amiga personal computer." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Android", Url = "http://www.openhandsetalliance.com/android_overview.html", Vendor = "Open Handset Alliance", Description = "Android is a mobile operating system that uses a modified version of the Linux kernel. It developed by Google." });
            os.Add(new OperatingSystemInfo { Family = "AROS", Name = "AROS", Url = "http://www.aros.org/", Vendor = "AROS Development Team", Description = "AROS Research Operating System is a free project that aims to be compatible with AmigaOS-level API." });
            os.Add(new OperatingSystemInfo { Family = "BeOS", Name = "BeOS", Url = "", Vendor = "Be, Inc.", Description = "BeOS was an operating system for personal computers which began development by Be Inc. in 1991." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Chromium OS", Url = "http://sites.google.com/a/chromium.org/dev/chromium-os", Vendor = "Google Inc.", Description = "Google Chrome is coming Linux OS-based, open source operating system designed by Google. Should work only with Web applications." });
            os.Add(new OperatingSystemInfo { Family = "DangerOS", Name = "Danger Hiptop", Url = "http://developer.danger.com/", Vendor = "Danger, Inc.", Description = "The Danger Hiptop, also re-branded as the T-Mobile Sidekick, is a GPRS/EDGE/UMTS smartphone manufactured by Danger Incorporated (since 2008, a subsidiary of Microsoft)." });
            os.Add(new OperatingSystemInfo { Family = "BSD", Name = "DragonFly BSD", Url = "http://www.dragonflybsd.org/", Vendor = "DragonFly BSD Team", Description = "DragonFly BSD is a free Unix-like operating system created as a fork of FreeBSD 4.8." });
            os.Add(new OperatingSystemInfo { Family = "BSD", Name = "FreeBSD", Url = "http://www.freebsd.org/", Vendor = "FreeBSD Foundation", Description = "FreeBSD is a free Unix-like operating system descended from AT&T UNIX via the Berkeley Software Distribution (BSD)." });
            os.Add(new OperatingSystemInfo { Family = "Haiku OS", Name = "Haiku OS", Url = "http://www.haiku-os.org/", Vendor = "Haiku Inc.", Description = "Haiku is a free open source operating system compatible with BeOS. Its development began in 2001." });
            os.Add(new OperatingSystemInfo { Family = "HP-UX", Name = "HP-UX", Url = "http://www.hp.com/products1/unix/", Vendor = "Hewlett-Packard Development Company, L.P.", Description = "HP-UX (Hewlett Packard UniX) is Hewlett-Packard's proprietary implementation of the UNIX operating system, based on System V." });
            os.Add(new OperatingSystemInfo { Family = "iPhone OS", Name = "iPhone OS", Url = "http://developer.apple.com/iphone/", Vendor = "Apple Inc.", Description = "iPhone OS (known as OS X or OS X iPhone in its early history) is a mobile operating system developed and marketed by Apple Inc." });
            os.Add(new OperatingSystemInfo { Family = "IRIX", Name = "IRIX", Url = "http://www.sgi.com/products/software/irix/", Vendor = "Silicon Graphics, Inc.", Description = "IRIX is a computer operating system developed by Silicon Graphics, Inc." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Jolicloud", Url = "http://www.jolicloud.com/", Vendor = "Tariq Krim and Romain Huet", Description = "Jolicloud is a Linux-based operating system for netbooks." });
            os.Add(new OperatingSystemInfo { Family = "JVM", Name = "JVM (Java)", Url = "http://java.sun.com/", Vendor = "Sun Microsystems, Inc.", Description = "A Java Virtual Machine (JVM) enables a set of computer software programs and data structures to use a virtual machine model for the execution of other computer programs and scripts." });
            os.Add(new OperatingSystemInfo { Family = "JVM", Name = "JVM (Platform Micro Edition)", Url = "http://java.sun.com/", Vendor = "Sun Microsystems, Inc.", Description = "Java Platform Micro Edition, or Java ME, is a Java platform designed for mobile devices and embedded systems." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux", Url = "http://en.wikipedia.org/wiki/Linux", Vendor = "", Description = "Linux is a generic term referring to Unix-like computer operating systems based on the Linux kernel." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (Arch Linux)", Url = "http://archlinux.org/", Vendor = "Judd Vinet", Description = "Arch Linux is an independent Linux distribution created by Judd Vinet." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (CentOS)", Url = "http://www.centos.org/", Vendor = "", Description = "CentOS (Community Enterprise Operating System) is freely available Linux distribution based on Red Hat Enterprise Linux." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (Debian)", Url = "http://www.debian.org/", Vendor = "Software in the Public Interest, Inc.", Description = "Debian is one of the oldest, so far developed distribution GNU/Linux." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (Fedora)", Url = "http://fedora.redhat.com/", Vendor = "Red Hat, Inc.", Description = "Fedora is a Linux distribution developed community of developers around the Fedora Project, sponsored by Red Hat." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (Gentoo)", Url = "http://www.gentoo.org/", Vendor = "Gentoo Foundation, Inc.", Description = "Gentoo Linux is source-based distribution, ie the entire system is compiled entirely from the base." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (Kanotix)", Url = "http://kanotix.com/", Vendor = "", Description = "Kanotix is an distribution (Live CD) based on Debian." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (Knoppix)", Url = "http://www.knoppix.net/", Vendor = "Klaus Knopper", Description = "Knoppix is probably the best known live CD Linux distribution." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (Linspire)", Url = "http://en.wikipedia.org/wiki/Linspire", Vendor = "Linspire, Inc.", Description = "Linspire, previously known as LindowsOS, was a commercial operating system based on Debian GNU/Linux and later Ubuntu." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (Maemo)", Url = "http://maemo.org/", Vendor = "Nokia", Description = "Maemo is a software platform developed by Nokia for smartphones and Internet Tablets. It is based on the Debian Linux distribution." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (Mandriva)", Url = "http://www.mandriva.com/", Vendor = "", Description = "Mandriva Linux (also formerly Mandrakelinux or Mandrake Linux) is a French Linux distribution." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (Mint)", Url = "http://linuxmint.com/", Vendor = "clem", Description = "Linux Mint is a distribution for personal computers is based on Ubuntu." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (RedHat)", Url = "http://www.redhat.com/rhel/", Vendor = "Red Hat, Inc.", Description = "Red Hat Enterprise Linux is a Linux distribution developed by the American Red Hat, which is designed for commercial use, including the mainframe." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (Slackware)", Url = "http://www.slackware.com/", Vendor = "Slackware Linux, Inc.", Description = "Slackware is a Linux distribution, the oldest still actively developed (the first version was released July 16, 1993)." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (SUSE)", Url = "http://www.novell.com/linux/", Vendor = "Novell, Inc.", Description = "SuSE is a Linux distribution. Its owned by Novell." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (Ubuntu)", Url = "http://www.ubuntulinux.org/", Vendor = "Canonical Ltd.", Description = "Ubuntu is a Linux distribution for desktops, based on Debian GNU/Linux. Ubuntu is sponsored by Canonical Ltd (owned by Mark Shuttleworth)." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "Linux (VectorLinux)", Url = "http://vectorlinux.com/", Vendor = "Robert S. Lange", Description = "VectorLinux, abbreviated VL, is a Linux distribution for the x86 platform based on the Slackware Linux distribution." });
            os.Add(new OperatingSystemInfo { Family = "Mac OS", Name = "Mac OS", Url = "http://en.wikipedia.org/wiki/Mac_OS", Vendor = "Apple Computer, Inc.", Description = "Mac OS is a designation of the original operating system for Apple Macintosh computers." });
            os.Add(new OperatingSystemInfo { Family = "Mac OS X", Name = "Mac OS X", Url = "http://www.apple.com/macosx/", Vendor = "Apple Computer, Inc.", Description = "Mac OS X is an operating system developed by Apple Inc.. Since 2002, Mac OS X has been included with all new Macintosh computer systems." });
            os.Add(new OperatingSystemInfo { Family = "Mac OS X", Name = "Mac OS X 10.3 Panther", Url = "http://www.apple.com/macosx/", Vendor = "Apple Computer, Inc.", Description = "Mac OS X is an operating system developed by Apple Inc.. Since 2002, Mac OS X has been included with all new Macintosh computer systems. Mac OS X 10.3 Panther since 2003/10/24." });
            os.Add(new OperatingSystemInfo { Family = "Mac OS X", Name = "Mac OS X 10.4 Tiger", Url = "http://www.apple.com/macosx/", Vendor = "Apple Computer, Inc.", Description = "Mac OS X is an operating system developed by Apple Inc.. Since 2002, Mac OS X has been included with all new Macintosh computer systems. Mac OS X 10.4 Tiger since 2005/04/29." });
            os.Add(new OperatingSystemInfo { Family = "Mac OS X", Name = "Mac OS X 10.5 Leopard", Url = "http://www.apple.com/macosx/", Vendor = "Apple Computer, Inc.", Description = "Mac OS X is an operating system developed by Apple Inc.. Since 2002, Mac OS X has been included with all new Macintosh computer systems. Mac OS X 10.5 Leopard since 2007/10/26." });
            os.Add(new OperatingSystemInfo { Family = "Mac OS X", Name = "Mac OS X 10.6 Snow Leopard", Url = "http://www.apple.com/macosx/", Vendor = "Apple Computer, Inc.", Description = "Mac OS X is an operating system developed by Apple Inc.. Since 2002, Mac OS X has been included with all new Macintosh computer systems. Mac OS X 10.6 Snow Leopard since 2009/8/29" });
            os.Add(new OperatingSystemInfo { Family = "MINIX", Name = "MINIX 3", Url = "http://www.minix3.org/", Vendor = "Andrew S. Tanenbaum", Description = "MINIX is a Unix-like computer operating system based on a microkernel architecture. Andrew S. Tanenbaum wrote the operating system to be used for educational purposes; MINIX also inspired the creation of the Linux kernel. Its name is a portmanteau of the words minimal and Unix. MINIX has been free and open source software since it was released under the BSD license in April 2000." });
            os.Add(new OperatingSystemInfo { Family = "MorphOS", Name = "MorphOS", Url = "http://www.morphos.org/", Vendor = "MorphOS development team", Description = "MorphOS is a computer operating system. It is a mixed proprietary and open source OS produced for the Pegasos PowerPC processor based computer." });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "MSN TV (WebTV)", Url = "http://www.msntv.com/", Vendor = "Microsoft Corporation.", Description = "MSN TV (formerly WebTV) is the a thin client which uses a television for display. The product was developed by WebTV Networks, Inc., a company purchased by Microsoft Corporation and absorbed into MSN." });
            os.Add(new OperatingSystemInfo { Family = "BSD", Name = "NetBSD", Url = "http://www.netbsd.org/", Vendor = "NetBSD Foundation, Inc.", Description = "NetBSD is a freely available open source version of the Unix-derivative Berkeley Software Distribution (BSD) computer operating system." });
            os.Add(new OperatingSystemInfo { Family = "Nintendo", Name = "Nintendo Wii", Url = "http://wii.nintendo.com/", Vendor = "Nintendo of America Inc.", Description = "Wii is the fifth video game console produced by Nintendo." });
            os.Add(new OperatingSystemInfo { Family = "BSD", Name = "OpenBSD", Url = "http://www.openbsd.org/", Vendor = "", Description = "" });
            os.Add(new OperatingSystemInfo { Family = "OpenVMS", Name = "OpenVMS", Url = "http://h71000.www7.hp.com/", Vendor = "Hewlett-Packard Development Company, L.P.", Description = "" });
            os.Add(new OperatingSystemInfo { Family = "OS/2", Name = "OS/2", Url = "http://en.wikipedia.org/wiki/OS/2", Vendor = "IBM Corporation", Description = "OS/2 operating system was IBM." });
            os.Add(new OperatingSystemInfo { Family = "OS/2", Name = "OS/2 Warp", Url = "http://www-306.ibm.com/software/os/warp/", Vendor = "IBM Corporation", Description = "OS/2 operating system was IBM. In 1994 he changed version numbering OS/2 No new version was OS/2 Warp x.x." });
            os.Add(new OperatingSystemInfo { Family = "Palm OS", Name = "Palm OS", Url = "http://en.wikipedia.org/wiki/Palm_OS", Vendor = "Palm, Inc.", Description = "Palm OS is a mobile operating system initially developed by Palm, Inc. for personal digital assistants (PDAs) in 1996." });
            os.Add(new OperatingSystemInfo { Family = "Linux", Name = "PClinuxOS", Url = "http://pclinuxos.com/", Vendor = "PCLinuxOS community", Description = "PCLinuxOS (often shortened to PCLOS) is Mandriva-based Linux distribution." });
            os.Add(new OperatingSystemInfo { Family = "Plan 9", Name = "Plan 9", Url = "http://plan9.bell-labs.com/plan9/", Vendor = "Lucent Technologies", Description = "Plan 9 from Bell Labs is a distributed operating system developed Bell Labs. Between 1984 and 2002 was developed as the successor to Unix.Plan 9 from Bell Labs je distribuovaný operační systém vyvíjený Bell Labs. Mezi lety 1984 a 2002 byl vyvíjen jako nástupce Unixu." });
            os.Add(new OperatingSystemInfo { Family = "QNX", Name = "QNX x86pc", Url = "http://www.qnx.com/", Vendor = "QNX Software Systems", Description = "QNX is a commercial operating system developed since 1980, QNX Software Systems company based in Canada." });
            os.Add(new OperatingSystemInfo { Family = "RIM OS", Name = "RIM OS", Url = "http://www.blackberry.com/", Vendor = "Research In Motion Limited", Description = "" });
            os.Add(new OperatingSystemInfo { Family = "RISK OS", Name = "RISK OS", Url = "", Vendor = "RISCOS Ltd", Description = "" });
            os.Add(new OperatingSystemInfo { Family = "SCO", Name = "SCO OpenServer", Url = "http://www.sco.com/products/openserver/", Vendor = "The SCO Group", Description = "" });
            os.Add(new OperatingSystemInfo { Family = "SkyOS", Name = "SkyOS", Url = "http://www.skyos.org/", Vendor = "SkyOS Team", Description = "" });
            os.Add(new OperatingSystemInfo { Family = "Solaris", Name = "Solaris", Url = "http://www.sun.com/software/solaris/", Vendor = "Sun Microsystems, Inc. (now Oracle Corporation)", Description = "Solaris (formerly SunOS) is a Unix operating system from Sun Microsystems (now Oracle). Solaris is also available as open source software project, OpenSolaris." });
            os.Add(new OperatingSystemInfo { Family = "Syllable", Name = "Syllable", Url = "http://syllable.org/", Vendor = "Kristian Van Der Vliet, Kaj de Vos, Rick Caudill, Arno Klenke, Henrik Isaksson", Description = "Syllable is a free operating system for platform 5x86 (Intel Pentium or higher). It is based on the then stagnant and now a dead operating system Atheos." });
            os.Add(new OperatingSystemInfo { Family = "Symbian OS", Name = "Symbian OS", Url = "http://www.symbian.org/", Vendor = "Symbian Foundation", Description = "Symbian OS is a free operating system that was designed for use in mobile devices. System created company Symbian Ltd.. Symbian OS is the successor to the system used in the EPOC Psion handheld computers." });
            os.Add(new OperatingSystemInfo { Family = "Palm OS", Name = "webOS", Url = "http://developer.palm.com/", Vendor = "Palm, Inc.", Description = "Palm webOS is a mobile operating system running on the Linux kernel with proprietary components developed by Palm." });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows", Url = "http://www.microsoft.com/windows/", Vendor = "Microsoft Corporation.", Description = "" });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows 2000", Url = "http://www.microsoft.com/windows2000/default.mspx", Vendor = "Microsoft Corporation.", Description = "" });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows 2003 Server", Url = "http://www.microsoft.com/windowsserver2003/default.mspx", Vendor = "Microsoft Corporation.", Description = "Windows Server 2003 server operating system from Microsoft. It is designed for the x86 PC platform and their enterprise version for 64-bit processors." });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows 3.x", Url = "http://www.microsoft.com/windows/", Vendor = "Microsoft Corporation.", Description = "Microsoft Windows 3.x is the third version of a graphic interface (GUI) for DOS issued in May 1990 by Microsoft." });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows 7", Url = "http://www.microsoft.com/windows/windows-7/", Vendor = "Microsoft Corporation.", Description = "Windows 7 is the next version of Microsoft Windows operating system and successor to Windows Vista." });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows 95", Url = "http://www.microsoft.com/windows95/", Vendor = "Microsoft Corporation.", Description = "Windows 95 is a graphical operating system. It was released on August 24, 1995 by Microsoft." });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows 98", Url = "http://www.microsoft.com/windows98/", Vendor = "Microsoft Corporation.", Description = "Windows 98 is a graphical operating system by Microsoft. Windows 98 is the successor to Windows 95." });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows CE", Url = "http://www.microsoft.com/windows/embedded/default.mspx", Vendor = "Microsoft Corporation.", Description = "Windows CE (official Windows Embedded CE, version 6.0 and also abbreviated WinCE) is Microsoft's operating system for small computers (Handheld PC, PDA)." });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows ME", Url = "http://www.microsoft.com/WindowsMe/", Vendor = "Microsoft Corporation.", Description = "Windows Me (Millennium Edition) is an operating system from Microsoft. Is more or less improving Windows 98 and the last system running as a superstructure of the MS-DOS." });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows Mobile", Url = "http://www.microsoft.com/windowsmobile/en-us/default.mspx", Vendor = "Microsoft Corporation.", Description = "Windows Mobile operating system of Microsoft, is the successor to Windows CE. It is designed for mobile devices." });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows NT", Url = "http://www.microsoft.com/windows/", Vendor = "Microsoft Corporation.", Description = "Windows NT is fully 32-bit Microsoft operating system for personal computers." });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows Phone 7", Url = "http://www.windowsphone7.com/", Vendor = "Microsoft Corporation.", Description = "" });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows Vista", Url = "http://www.microsoft.com/windowsvista/", Vendor = "Microsoft Corporation.", Description = "Windows Vista is a version of Windows from Microsoft." });
            os.Add(new OperatingSystemInfo { Family = "Windows", Name = "Windows XP", Url = "http://www.microsoft.com/windowsxp/default.mspx", Vendor = "Microsoft Corporation.", Description = "Windows XP is an operating system produced by Microsoft for use on personal computers, including home and business desktops, laptops, and media centers. It was released in 2001. The name \"XP\" is short for \"eXPerience\"." });
            os.Add(new OperatingSystemInfo { Family = "XrossMediaBar (XMB)", Name = "XrossMediaBar (XMB)", Url = "http://en.wikipedia.org/wiki/XrossMediaBar", Vendor = "Sony Computer Entertainment", Description = "The XrossMediaBar (pronounced CrossMediaBar and officially abbreviated as XMB) is a graphical user interface developed by Sony Computer Entertainment. The XMB is used as the default interface on both the PlayStation Portable and the PlayStation 3." });
            return os;
        }

        /// <summary>
        /// Get list of browsers.
        /// <see cref="http://user-agent-string.info/list-of-ua"/>
        /// </summary>
        /// <returns>List of browsers.</returns>
        public static List<BrowserInfo> GetBrowsers()
        {
            List<string> userAgents = new List<string>();

            List<BrowserInfo> browsers = new List<BrowserInfo>();

            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; JyxoToolbar1.0; http://www.Abolimba.de; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 1.1.4322)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows 98; Win 9x 4.90; http://www.Abolimba.de)");
            browsers.Add(new BrowserInfo { Name = "Abolimba", Producer = "Mathias Gerlach, Jochen Milchsack ", ProductPage = "http://www.aborange.de/products/freeware/abolimba-multibrowser.php ", LayoutEngine = "Trident", Description = "Abolimba Mutlibrowser is German (IE based) browser for Windows.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (compatible; U; ABrowse 0.6; Syllable) AppleWebKit/420+ (KHTML, like Gecko)");
            userAgents.Add("Mozilla/5.0 (compatible; ABrowse 0.4; Syllable)");
            browsers.Add(new BrowserInfo { Name = "ABrowse", Producer = "Kurt Skauen ", ProductPage = "http://en.wikipedia.org/wiki/ABrowse ", LayoutEngine = "WebKit", Description = "ABrowse is a web browser for the Syllable OS.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; Acoo Browser; SLCC1; .NET CLR 2.0.50727; Media Center PC 5.0; .NET CLR 3.0.04506)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Acoo Browser; InfoPath.2; .NET CLR 2.0.50727; Alexa Toolbar)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Acoo Browser; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
            browsers.Add(new BrowserInfo { Name = "Acoo Browser", Producer = "", ProductPage = "http://www.acoobrowser.com/ ", LayoutEngine = "Trident", Description = "Multi-tabbed Internet browser based on the Internet Explorer.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("amaya/9.52 libwww/5.4.0");
            userAgents.Add("amaya/11.1 libwww/5.4.0");
            browsers.Add(new BrowserInfo { Name = "Amaya", Producer = "World Wide Web Consortium ", ProductPage = "http://www.w3.org/Amaya/ ", LayoutEngine = "Proprietary", Description = "Amaya is a Web editor/browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Amiga-AWeb/3.5.07 beta");
            browsers.Add(new BrowserInfo { Name = "Amiga Aweb", Producer = "AmiTrix Development Inc. ", ProductPage = "http://aweb.sunsite.dk/ ", LayoutEngine = "Proprietary", Description = "AWeb is a web browser for the Amiga range of computers. Originally developed by Yvon Rozijn, AWeb was shipped with version 3.9 of AmigaOS, and is now open source.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("AmigaVoyager/3.4.4 (MorphOS/PPC native)");
            userAgents.Add("AmigaVoyager/2.95 (compatible; MC680x0; AmigaOS)");
            browsers.Add(new BrowserInfo { Name = "Amiga Voyager", Producer = "VaporWare ", ProductPage = "http://v3.vapor.com/ ", LayoutEngine = "Proprietary", Description = "Shareware browser for all you Amiga/MorphOS.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; AOL 6.0; Windows NT 5.1)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; AOL 7.0; Windows NT 5.1; FunWebProducts)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; AOL 9.0; Windows NT 5.1; .NET CLR 1.1.4322; Zango 10.1.181.0)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; AOL 9.5; AOLBuild 4337.35; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; AOL 8.0; Windows NT 5.1; SV1)");
            browsers.Add(new BrowserInfo { Name = "AOL Explorer", Producer = "America Online, Inc. ", ProductPage = "http://daol.aol.com/software/ ", LayoutEngine = "Trident", Description = "AOL Explorer, previously known as AOL Browser, is a graphical web browser based on the Microsoft Trident layout engine and was released by AOL. In July 2005.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux; C -) AppleWebKit/523.15 (KHTML, like Gecko, Safari/419.3) Arora/0.5");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; zh-CN) AppleWebKit/523.15 (KHTML, like Gecko, Safari/419.3) Arora/0.3 (Change: 287 c9dfb30)");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux; en-US) AppleWebKit/527+ (KHTML, like Gecko, Safari/419.3) Arora/0.6");
            browsers.Add(new BrowserInfo { Name = "Arora", Producer = "Benjamin Meyer ", ProductPage = "http://arora.googlecode.com/ ", LayoutEngine = "WebKit", Description = "Arora is a simple cross platform web browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; GTB5; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; Avant Browser)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; Avant Browser; Avant Browser; .NET CLR 1.1.4322; .NET CLR 2.0.50727; InfoPath.1)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; JyxoToolbar1.0; Embedded Web Browser from: http://bsalsa.com/; Avant Browser; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 1.1.4322)");
            userAgents.Add("Avant Browser (http://www.avantbrowser.com)");
            browsers.Add(new BrowserInfo { Name = "Avant Browser", Producer = "Avant Force ", ProductPage = "http://avantbrowser.com/ ", LayoutEngine = "Trident", Description = "", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; WinNT; en; rv:1.0.2) Gecko/20030311 Beonex/0.8.2-stable");
            userAgents.Add("Mozilla/5.0 (Windows; U; Win9x; en; Stable) Gecko/20020911 Beonex/0.8.1-stable");
            userAgents.Add("Mozilla/5.0 (Windows; U; WinNT; en; Preview) Gecko/20020603 Beonex/0.8-stable");
            browsers.Add(new BrowserInfo { Name = "Beonex", Producer = "Ben Bucksch ", ProductPage = "http://www.beonex.com/ ", LayoutEngine = "Gecko", Description = "Beonex Communicator belongs to the Mozilla family of browsers, i.e. is a sibling of Netscape 7. Beonex Communicator contains: Navigator (browser), Mailnews (email/news client) and Composer (web page editor).", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9) Gecko/2008120120 Blackbird/0.9991");
            browsers.Add(new BrowserInfo { Name = "Blackbird", Producer = "40A, Inc.", ProductPage = "http://www.blackbirdbrowser.com/ ", LayoutEngine = "Gecko", Description = "Blackbird is Firefox-based browser. Is designed for African Americans, offering tools, content integration, and search features tailed towards the community.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; 78; CentOS; US-en) AppleWebKit/527+ (KHTML, like Gecko) Bolt/0.862 Version/3.0 Safari/523.15");
            browsers.Add(new BrowserInfo { Name = "Bolt", Producer = "Bitstream", ProductPage = "http://boltbrowser.com/ ", LayoutEngine = "WebKit", Description = "Mobile browser based on AppleWebKit", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.61 [en] (X11; U; ) - BrowseX (2.0.0 Windows)");
            browsers.Add(new BrowserInfo { Name = "BrowseX", Producer = "Peter MacDonald ", ProductPage = "http://pdqi.com/browsex/ ", LayoutEngine = "Tkhtml", Description = "BrowseX is a free Open Source, cross-platform Web Browser, Mail Program, Talk/Chat client and more. Development was stopped in 2003.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Browzar)");
            browsers.Add(new BrowserInfo { Name = "Browzar", Producer = "Browzar Ltd", ProductPage = "http://www.browzar.com/ ", LayoutEngine = "Trident", Description = "Browzar is free, it only takes seconds to download and you dont even need to install it, so you can download Browzar time and time again, whenever and wherever you need it to protect your privacy. No browsing history, stored files, or cookies, no embarrassing search auto-complete, no installation--just click 'run' and go, and no registration required.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Bunjalloo/0.7.6(Nintendo DS;U;en)");
            userAgents.Add("Bunjalloo/0.7.4(Nintendo DS;U;en)");
            browsers.Add(new BrowserInfo { Name = "Bunjalloo", Producer = "quirkysoft", ProductPage = "http://code.google.com/p/quirkysoft/ ", LayoutEngine = "??", Description = "Bunjalloo is a web browser for the Nintendo DS.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X Mach-O; en; rv:1.8.1.4pre) Gecko/20070511 Camino/1.6pre");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X Mach-O; en; rv:1.8.1.12) Gecko/20080206 Camino/1.5.5");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X Mach-O; en-US; rv:1.8.0.10) Gecko/20070228 Camino/1.0.4");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X Mach-O; en-US; rv:1.7.2) Gecko/20040825 Camino/0.8.1");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X Mach-O; en-US; rv:1.0.1) Gecko/20030111 Chimera/0.6");
            browsers.Add(new BrowserInfo { Name = "Camino", Producer = "Mozilla Foundation ", ProductPage = "http://www.caminobrowser.org/ ", LayoutEngine = "Gecko", Description = "Camino is an open source web browser developed with a focus on providing the best possible experience for Mac OS X users. Camino combines the awesome visual and behavioral experience that has been central to the Macintosh philosophy with the powerful web-browsing capabilities of the Gecko rendering engine.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X; en) AppleWebKit/419 (KHTML, like Gecko, Safari/419.3) Cheshire/1.0.ALPHA");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X; en) AppleWebKit/418.9 (KHTML, like Gecko, Safari) Safari/419.3 Cheshire/1.0.ALPHA");
            browsers.Add(new BrowserInfo { Name = "Cheshire", Producer = "AOL LLC ", ProductPage = "http://greenhouse.aol.com/prod.jsp?prod_id=32 ", LayoutEngine = "WebKit", Description = "Cheshire is a test of an AOL product for the Macintosh.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/525.19 (KHTML, like Gecko) Chrome/1.0.154.53 Safari/525.19");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/525.19 (KHTML, like Gecko) Chrome/1.0.154.36 Safari/525.19");
            browsers.Add(new BrowserInfo { Name = "Chrome", Producer = "Google Inc. ", ProductPage = "http://www.google.com/chrome ", LayoutEngine = "WebKit", Description = "Free open-source web browser developed by Google.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.0.5) Gecko/2009011615 Firefox/3.0.5 CometBird/3.0.5");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.10) Gecko/2009042815 Firefox/3.0.10 CometBird/3.0.10");
            browsers.Add(new BrowserInfo { Name = "CometBird", Producer = "cometbird.com", ProductPage = "http://www.cometbird.com/ ", LayoutEngine = "Gecko", Description = "CometBird is developed from the source codes of Mozilla FireFox and also follow the source code license of Mozilla. ", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/532.0 (KHTML, like Gecko) Comodo_Dragon/1.0.0.9 Chrome/ Version/3.2.1 Safari/532.0");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/532.0 (KHTML, like Gecko) Comodo_Dragon/1.0.0.9 Chrome/ Version/3.2.1 Safari/532.0");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.2; en-US) AppleWebKit/532.0 (KHTML, like Gecko) Comodo_Dragon/1.0.0.5 Safari/532.0");
            browsers.Add(new BrowserInfo { Name = "Comodo Dragon", Producer = "Comodo Group, Inc. ", ProductPage = "http://www.comodo.com/home/internet-security/browser.php ", LayoutEngine = "WebKit", Description = "Web browser Chromium-based from Comodo Group Company, Inc.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2.10) Gecko/20100914 Conkeror/0.9.3");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.1.11) Gecko/20100721 Conkeror/0.9.2 (Debian-0.9.2+git100804-1)");
            browsers.Add(new BrowserInfo { Name = "Conkeror", Producer = "Mozilla Foundation ", ProductPage = "http://conkeror.org/ ", LayoutEngine = "Gecko", Description = "Conkeror is a keyboard-oriented (EMACS-like) web browser based on Mozilla XULRunner.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Crazy Browser 1.0.5; .NET CLR 1.1.4322; InfoPath.1)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727; Crazy Browser 3.0.0 Beta2)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.1.4322; Crazy Browser 2.0.1)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; Crazy Browser 1.0.5)");
            browsers.Add(new BrowserInfo { Name = "Crazy Browser", Producer = "CrazyBrowser.com ", ProductPage = "http://www.crazybrowser.com/ ", LayoutEngine = "Trident", Description = "Crazy Browser is based on IE, and by all is the same as AM Browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; Deepnet Explorer 1.5.0; .NET CLR 1.0.3705)");
            browsers.Add(new BrowserInfo { Name = "Deepnet Explorer", Producer = "Deepnet Technologies Ltd ", ProductPage = "http://www.deepnetexplorer.com/ ", LayoutEngine = "Trident", Description = "Based on IE. With RSS and P2P suport.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_5_6; en-us) AppleWebKit/525.27.1 (KHTML, like Gecko) Demeter/1.0.9 Safari/125");
            browsers.Add(new BrowserInfo { Name = "Demeter", Producer = "hurrikenux Creative ", ProductPage = "http://www.hurrikenux.com/Demeter/ ", LayoutEngine = "WebKit", Description = "Browser for MAC OS based on browser Shiira.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X; pl-pl) AppleWebKit/312.8 (KHTML, like Gecko, Safari) DeskBrowse/1.0");
            browsers.Add(new BrowserInfo { Name = "DeskBrowse", Producer = "Off Leash Developments, Inc ", ProductPage = "http://www.deskbrowse.org/ ", LayoutEngine = "WebKit", Description = "Open source web browser for Mac OS X.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Dillo/0.8.5");
            userAgents.Add("Dillo/2.0");
            browsers.Add(new BrowserInfo { Name = "Dillo", Producer = "", ProductPage = "http://www.dillo.org/ ", LayoutEngine = "Proprietary", Description = "Dillo is a multi-platform web browser. Dillo is written in C and C++. ", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("DocZilla/2.7 (Windows; U; Windows NT 5.1; en-US; rv:2.7.0) Gecko/20050706 CiTEC Information");
            userAgents.Add("DocZilla/1.0 (Windows; U; WinNT4.0; en-US; rv:1.0.0) Gecko/20020804");
            browsers.Add(new BrowserInfo { Name = "DocZilla", Producer = "CITEC ", ProductPage = "http://www.doczilla.com/ ", LayoutEngine = "Gecko", Description = "DocZilla is a standard Mozilla that contains extra components providing parsing and displaying SGML/XML documents on the fly without a precompilation step.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; cs-CZ) AppleWebKit/527+ (KHTML, like Gecko, Safari/419.3) Dooble");
            browsers.Add(new BrowserInfo { Name = "Dooble", Producer = "Dooble team", ProductPage = "http://dooble.sourceforge.net/ ", LayoutEngine = "WebKit", Description = "Dooble is GNU browser based on WebKit and contains Dooble Search. Dooble Search is powered by YaCy and the Metager YaCy Portal. Dooble is available for popular operating systems Windows, OS X and GNU/Linux.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Doris/1.15 [en] (Symbian)");
            browsers.Add(new BrowserInfo { Name = "Doris", Producer = "Anygraaf ", ProductPage = "http://www.anygraaf.fi/browser/indexe.htm ", LayoutEngine = "??", Description = "Web browser for Symbian Series 60", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("edbrowse/2.2.10");
            userAgents.Add("edbrowse/3.1.2-1");
            userAgents.Add("edbrowse/1.5.17-2");
            browsers.Add(new BrowserInfo { Name = "Edbrowse", Producer = "Karl Dahlke", ProductPage = "http://edbrowse.sourceforge.net/ ", LayoutEngine = "n/a", Description = "Edbrowse is a combination editor, browser, and mail client that is 100% text based.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/533+ (KHTML, like Gecko) Element Browser 5.0");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; cs-CZ) AppleWebKit/533+ (KHTML, like Gecko) Element Browser 6.0");
            browsers.Add(new BrowserInfo { Name = "Element Browser", Producer = "Element Software UK. ", ProductPage = "http://www.elementsoftware.co.uk/software/elementbrowser/ ", LayoutEngine = "WebKit/Trident", Description = "Element Browser is a Web browser with an intuitive user interface.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("ELinks/0.13.GIT (textmode; Linux 2.6.22-2-686 i686; 148x68-3)");
            userAgents.Add("ELinks/0.9.3 (textmode; Linux 2.6.11 i686; 79x24)");
            browsers.Add(new BrowserInfo { Name = "Elinks", Producer = "Mikulas Patocka", ProductPage = "http://elinks.or.cz/ ", LayoutEngine = "Proprietary", Description = "Text WWW Browser based on browser Links.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Enigma Browser");
            browsers.Add(new BrowserInfo { Name = "Enigma browser", Producer = "Advanced Search Technologies, Inc. ", ProductPage = "http://www.suttondesigns.com/ ", LayoutEngine = "Trident", Description = "based on IE", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.7.3) Gecko/20041007 Epiphany/1.4.7");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en; rv:1.8.1.12) Gecko/20080208 (Debian-1.8.1.12-2) Epiphany/2.20");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux x86_64; en; rv:1.9.0.12) Gecko/20080528 Fedora/2.24.3-8.fc10 Epiphany/2.22 Firefox/3.0");
            browsers.Add(new BrowserInfo { Name = "Epiphany", Producer = "GNOME Foundation ", ProductPage = "http://www.gnome.org/projects/epiphany/ ", LayoutEngine = "WebKit/Gecko", Description = "Epiphany is the web browser for the GNOME desktop.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 5.23; Macintosh; PPC) Escape 5.1.1");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 5.23; Macintosh; PPC) Escape 5.1.8");
            browsers.Add(new BrowserInfo { Name = "Espial TV Browser", Producer = "Espial Group ", ProductPage = "http://www.espial.com/products/evo_browser/ ", LayoutEngine = "WebKit", Description = "Espial TV Browser (formerly branded as the Espial Escape Browser) is an embedded web browser for IPTV Set-top box from Espial Group.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Win98; en-US; rv:1.5) Gecko/20031007 Firebird/0.7");
            userAgents.Add("Mozilla/5.0 (Windows; U; Win95; en-US; rv:1.5) Gecko/20031007 Firebird/0.7");
            browsers.Add(new BrowserInfo { Name = "Firebird (old name for Firefox)", Producer = "Mozilla Foundation ", ProductPage = "http://www.mozilla.org/products/firefox/ ", LayoutEngine = "Gecko", Description = "Former name of the Mozilla Firefox browser (also formerly known as Phoenix)", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10.5; en-US; rv:1.9.1b3) Gecko/20090305 Firefox/3.1b3 GTB5");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10.5; ko; rv:1.9.1b2) Gecko/20081201 Firefox/3.1b2");
            userAgents.Add("Mozilla/5.0 (X11; U; SunOS sun4u; en-US; rv:1.9b5) Gecko/2008032620 Firefox/3.0b5");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.8.1.12) Gecko/20080214 Firefox/2.0.0.12");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; cs; rv:1.9.0.8) Gecko/2009032609 Firefox/3.0.8");
            userAgents.Add("Mozilla/5.0 (X11; U; OpenBSD i386; en-US; rv:1.8.0.5) Gecko/20060819 Firefox/1.5.0.5");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.0; es-ES; rv:1.8.0.3) Gecko/20060426 Firefox/1.5.0.3");
            userAgents.Add("Mozilla/5.0 (Windows; U; WinNT4.0; en-US; rv:1.7.9) Gecko/20050711 Firefox/1.0.5");
            userAgents.Add("Mozilla/5.0 (Windows; Windows NT 6.1; rv:2.0b2) Gecko/20100720 Firefox/4.0b2");
            browsers.Add(new BrowserInfo { Name = "Firefox", Producer = "Mozilla Foundation ", ProductPage = "http://www.mozilla.org/products/firefox/ ", LayoutEngine = "Gecko", Description = "Mozilla Firefox is a free multi-platform Web browser, which is developing in cooperation with hundreds of volunteers, Mozilla Corporation, a subsidiary of the Foundation Mozilla Foundation.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (BeOS; U; Haiku BePC; en-US; rv:1.8.1.21pre) Gecko/20090227 BonEcho/2.0.0.21pre");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1.9) Gecko/20071113 BonEcho/2.0.0.9");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1) Gecko/20061026 BonEcho/2.0");
            browsers.Add(new BrowserInfo { Name = "Firefox (BonEcho)", Producer = "Mozilla Foundation ", ProductPage = "http://www.mozilla.org/projects/bonecho/releases/2.0a1.html ", LayoutEngine = "Gecko", Description = "BonEcho is a developer preview release of the next generation Firefox browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.0.8) Gecko/2009033017 GranParadiso/3.0.8");
            browsers.Add(new BrowserInfo { Name = "Firefox (GranParadiso)", Producer = "Mozilla Foundation ", ProductPage = "https://wiki.mozilla.org/Firefox3 ", LayoutEngine = "Gecko", Description = "GranParadiso is an developer preview release for the next major version of Firefox.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10.6; en-US; rv:1.9.2) Gecko/20100411 Lorentz/3.6.3 GTB7.0");
            browsers.Add(new BrowserInfo { Name = "Firefox (Lorentz)", Producer = "Mozilla Foundation ", ProductPage = "http://www.mozilla.com/en-US/firefox/lorentz/ ", LayoutEngine = "Gecko", Description = "Lorentz is an developer preview release for the next major version of Firefox.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; it; rv:1.9.3a1pre) Gecko/20091019 Minefield/3.7a1pre");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.0; en-US; rv:1.9.3a4pre) Gecko/20100402 Minefield/3.7a4pre");
            browsers.Add(new BrowserInfo { Name = "Firefox (Minefield)", Producer = "Mozilla Foundation ", ProductPage = "http://www.mozilla.org/projects/minefield/ ", LayoutEngine = "Gecko", Description = "Minefield is a codename for Mozilla Firefox nightly \"trunk build\".", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.9.2a2pre) Gecko/20090901 Ubuntu/9.10 (karmic) Namoroka/3.6a2pre");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2a1) Gecko/20090806 Namoroka/3.6a1");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; cs; rv:1.9.2a2pre) Gecko/20090912 Namoroka/3.6a2pre (.NET CLR 3.5.30729)");
            browsers.Add(new BrowserInfo { Name = "Firefox (Namoroka)", Producer = "Mozilla Foundation ", ProductPage = "https://wiki.mozilla.org/Firefox/Namoroka ", LayoutEngine = "Gecko", Description = "Namoroka is an early developer milestone for the next version of Firefox.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.9.1b3pre) Gecko/20090109 Shiretoko/3.1b3pre");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.1b4pre) Gecko/20090311 Shiretoko/3.1b4pre");
            browsers.Add(new BrowserInfo { Name = "Firefox (Shiretoko)", Producer = "Mozilla Foundation ", ProductPage = "http://www.mozilla.org/projects/firefox/3.1a1/releasenotes/ ", LayoutEngine = "Gecko", Description = "Shiretoko is an early developer milestone for the next version of Firefox.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X Mach-O; en-US; rv:1.8.0.1) Gecko/20060314 Flock/0.5.13.2");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.9.0.2) Gecko/2008092122 Firefox/3.0.2 Flock/2.0b3");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/532.5 (KHTML, like Gecko) Flock/3.0.0.3737 Chrome/4.1.249.1071 Safari/532.5");
            browsers.Add(new BrowserInfo { Name = "Flock", Producer = "Flock, Inc. ", ProductPage = "http://www.flock.com/ ", LayoutEngine = "Gecko/WebKit", Description = "Flock is a free multi-platform web browser developed by Flock company. Previously was based on Firefox. From version 3 based on the Chrome browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/525.13 (KHTML, like Gecko) Fluid/0.9.4 Safari/525.13");
            browsers.Add(new BrowserInfo { Name = "Fluid", Producer = "Todd Ditchendorf ", ProductPage = "http://fluidapp.com/ ", LayoutEngine = "WebKit", Description = "Free browser for Mac OS", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.7.12) Gecko/20050929 Galeon/1.3.21");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.0.8) Gecko/20090327 Galeon/2.0.7");
            browsers.Add(new BrowserInfo { Name = "Galeon", Producer = "GNOME Foundation ", ProductPage = "http://galeon.sourceforge.net/ ", LayoutEngine = "Gecko", Description = "Galeon is a web browser for GNOME based on Mozilla’s Gecko layout engine.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.5) Gecko/20091105 Firefox/3.5.5 compat GlobalMojo/1.5.5 GlobalMojoExt/1.5");
            browsers.Add(new BrowserInfo { Name = "GlobalMojo", Producer = "KPG VENTURES ", ProductPage = "http://globalmojo.com/ ", LayoutEngine = "Gecko", Description = "GlobalMojo apparently helps to generate money and by 50% of all has to go to charities, well who knows.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; GreenBrowser)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 2.0.50727; GreenBrowser)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; InfoPath.1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.30; GreenBrowser)");
            browsers.Add(new BrowserInfo { Name = "GreenBrowser", Producer = "More Quick Tools ", ProductPage = "http://www.morequick.com/indexen.htm ", LayoutEngine = "Trident", Description = "IE based browser from the Chinese Company MoreQuick.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("HotJava/1.1.2 FCS");
            userAgents.Add("Mozilla/3.0 (x86 [cs] Windows NT 5.1; Sun)");
            browsers.Add(new BrowserInfo { Name = "HotJava", Producer = "Sun Microsystems, Inc. ", ProductPage = "http://java.sun.com/products/archive/hotjava/index.html ", LayoutEngine = "Java", Description = "browser write in Java.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.1 (X11; U; Linux i686; en-US; rv:1.8.0.3) Gecko/20060425 SUSE/1.5.0.3-7 Hv3/alpha");
            browsers.Add(new BrowserInfo { Name = "Hv3", Producer = "tkhtml.tcl.tk ", ProductPage = "http://tkhtml.tcl.tk/hv3.html ", LayoutEngine = "Tkhtml3", Description = "Hv3 is minimalist web browser that uses Tkhtml3 as a rendering engine and SEE (Simple ECMAScript Engine) to interpret scripts.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; SIMBAR={CFBFDAEA-F21E-4D6E-A9B0-E100A69B860F}; Hydra Browser; .NET CLR 2.0.50727; .NET CLR 1.1.4322; .NET CLR 3.0.04506.30)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Hydra Browser; .NET CLR 2.0.50727; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)");
            browsers.Add(new BrowserInfo { Name = "Hydra Browser", Producer = "Quantum", ProductPage = "http://hydrabrowser.com/ ", LayoutEngine = "Trident", Description = "Hydra is an alternative web browser featuring Office 2007 style GUI.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("IBrowse/2.3 (AmigaOS 3.9)");
            userAgents.Add("Mozilla/5.0 (compatible; IBrowse 3.0; AmigaOS4.0)");
            browsers.Add(new BrowserInfo { Name = "IBrowse", Producer = "Omnipresence Intl. ", ProductPage = "http://www.ibrowse-dev.net/ ", LayoutEngine = "Proprietary", Description = "IBrowse is an MUI-based web browser for the Amiga range of computers, and was a rewritten follow-on to Amiga Mosaic.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.5 (compatible; iCab 2.9.1; Macintosh; U; PPC)");
            userAgents.Add("iCab/3.0.2 (Macintosh; U; PPC Mac OS X)");
            userAgents.Add("iCab/4.0 (Macintosh; U; Intel Mac OS X)");
            browsers.Add(new BrowserInfo { Name = "iCab", Producer = "Alexander Clauss", ProductPage = "http://www.icab.de/ ", LayoutEngine = "WebKit", Description = "iCab is a shareware web browser for the Apple Macintosh. ", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Java 1.6.0_01; Windows XP 5.1 x86; en) ICEbrowser/v6_1_2");
            userAgents.Add("ICE Browser/5.05 (Java 1.4.0; Windows 2000 5.0 x86)");
            userAgents.Add("ICE Browser/v5_4_3 (Java 1.4.2; Windows XP 5.1 x86)");
            browsers.Add(new BrowserInfo { Name = "ICE browser", Producer = "ICEsoft Technologies Inc. ", ProductPage = "http://www.icesoft.com/products/icebrowser.html ", LayoutEngine = "Java", Description = "The ICEbrowser is browser write in Java.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1.9) Gecko/20071030 Iceape/1.1.6 (Debian-1.1.6-3)");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.8.1.8) Gecko/20071008 Iceape/1.1.5 (Ubuntu-1.1.5-1ubuntu0.7.10)");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux ppc; en-US; rv:1.8.1.13) Gecko/20080313 Iceape/1.1.9 (Debian-1.1.9-5)");
            browsers.Add(new BrowserInfo { Name = "IceApe", Producer = "Software in the Public Interest, Inc. ", ProductPage = "http://www.debian.org/ ", LayoutEngine = "Gecko", Description = "the GNU version of the SeaMonkey browser - Debian fork SeaMonkey", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1.11) Gecko/20071203 IceCat/2.0.0.11-g1");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.0.3) Gecko/2008092921 IceCat/3.0.3-g1");
            browsers.Add(new BrowserInfo { Name = "IceCat", Producer = "Free Software Foundation, Inc. ", ProductPage = "http://www.gnu.org/software/gnuzilla/ ", LayoutEngine = "Gecko", Description = "IceCat is the GNU version of the Firefox browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; it; rv:1.9.0.5) Gecko/2008122011 Iceweasel/3.0.5 (Debian-3.0.5-1)");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; de; rv:1.9.0.5) Gecko/2008122011 Iceweasel/3.0.5 (Debian-3.0.5-1)");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.8.1.1) Gecko/20061205 Iceweasel/2.0.0.1 (Debian-2.0.0.1+dfsg-4)");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; pt-PT; rv:1.9.2.3) Gecko/20100402 Iceweasel/3.6.3 (like Firefox/3.6.3) GTB7.0");
            browsers.Add(new BrowserInfo { Name = "IceWeasel", Producer = "Software in the Public Interest, Inc. ", ProductPage = "http://www.gnu.org/software/gnuzilla/ ", LayoutEngine = "Gecko", Description = "the GNU version of the Firefox browser - Debian fork Firefox", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 5.0; Windows NT;)");
            userAgents.Add("Mozilla/4.0 (Windows; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0; GTB5; SLCC1; .NET CLR 2.0.50727; Media Center PC 5.0; .NET CLR 3.0.04506; InfoPath.2; OfficeLiveConnector.1.3; OfficeLivePatch.0.0)");
            userAgents.Add("Mozilla/4.0 (Mozilla/4.0; MSIE 7.0; Windows NT 5.1; FDM; SV1; .NET CLR 3.0.04506.30)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 1.0.3705; .NET CLR 1.1.4322; Media Center PC 4.0; .NET CLR 2.0.50727)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 5.0b1; Mac_PowerPC)");
            userAgents.Add("Mozilla/2.0 (compatible; MSIE 4.0; Windows 98)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 5.01; Windows NT)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 5.23; Mac_PowerPC)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; GTB6; Ant.com Toolbar 1.6; MSIECrawler)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; Trident/4.0; SLCC1; .NET CLR 2.0.50727; .NET CLR 1.1.4322; InfoPath.2; .NET CLR 3.5.21022; .NET CLR 3.5.30729; MS-RTC LM 8; OfficeLiveConnector.1.4; OfficeLivePatch.1.3; .NET CLR 3.0.30729)");
            userAgents.Add("Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)");
            browsers.Add(new BrowserInfo { Name = "IE", Producer = "Microsoft Corporation. ", ProductPage = "http://www.microsoft.com/ie/ ", LayoutEngine = "Trident", Description = "Windows Internet Explorer (formerly Microsoft Internet Explorer; abbreviated to MSIE or, more commonly, IE), is a series of graphical web browsers developed by Microsoft.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; Trident/4.0; SLCC1; .NET CLR 2.0.50727; .NET CLR 1.1.4322; InfoPath.2; .NET CLR 3.5.21022; .NET CLR 3.5.30729; MS-RTC LM 8; OfficeLiveConnector.1.4; OfficeLivePatch.1.3; .NET CLR 3.0.30729)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; InfoPath.2)");
            browsers.Add(new BrowserInfo { Name = "IE 8.0 (Compatibility View)", Producer = "Microsoft Corporation. ", ProductPage = "http://blogs.msdn.com/ie/archive/2008/08/27/introducing-compatibility-view.aspx ", LayoutEngine = "Trident", Description = "MSIE 8.0 run in \"Compatibility View\"", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; iRider 2.21.1108; FDM)");
            browsers.Add(new BrowserInfo { Name = "iRider", Producer = "Wymea Bay ", ProductPage = "http://www.irider.com/irider/index.htm ", LayoutEngine = "Trident", Description = "Comercial IE based browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US) AppleWebKit/528.5 (KHTML, like Gecko) Iron/0.4.155.0 Safari/528.5");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/528.7 (KHTML, like Gecko) Iron/1.0.155.0 Safari/528.7");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/525.19 (KHTML, like Gecko) Iron/0.2.152.0 Safari/12081672.525");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/531.0 (KHTML, like Gecko) Iron/3.0.189.0 Safari/531.0");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US) AppleWebKit/533.1 (KHTML, like Gecko) Iron/5.0.326.0 Chrome/5.0.326.0 Safari/533.1");
            browsers.Add(new BrowserInfo { Name = "Iron", Producer = "", ProductPage = "http://www.srware.net/en/software_srware_iron.php ", LayoutEngine = "WebKit", Description = "based on the free Sourcecode \"Chromium\" (the google browser)", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.8.1.19) Gecko/20081217 K-Meleon/1.5.2");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.21) Gecko/20090331 K-Meleon/1.5.3");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.5) Gecko/20060706 K-Meleon/1.0");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.0; en-US; rv:1.8.1.21) Gecko/20090331 K-Meleon/1.5.3");
            browsers.Add(new BrowserInfo { Name = "K-Meleon", Producer = "Adnrew Mutch ", ProductPage = "http://kmeleon.sourceforge.net/ ", LayoutEngine = "Gecko", Description = "K-Meleon is lightweight web browser based on the Gecko layout engine. K-Meleon is designed for Microsoft Windows (Win32) operating systems. ", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.0.6) Gecko/20060731 K-Ninja/2.0.2");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.2pre) Gecko/20070215 K-Ninja/2.1.1");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.8.1.4pre) Gecko/20070404 K-Ninja/2.1.3");
            browsers.Add(new BrowserInfo { Name = "K-Ninja", Producer = "", ProductPage = "http://www.geocities.com/grenleef/ ", LayoutEngine = "Gecko", Description = "K-Ninja id minimalistic modification of K-Meleon. ", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; zh-CN; rv:1.9) Gecko/20080705 Firefox/3.0 Kapiko/3.0");
            browsers.Add(new BrowserInfo { Name = "Kapiko", Producer = "Ufox lab.", ProductPage = "http://ufoxlab.googlepages.com/ ", LayoutEngine = "Gecko", Description = "", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; Linux i686; U;) Gecko/20070322 Kazehakase/0.4.5");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.0.8) Gecko Fedora/1.9.0.8-1.fc10 Kazehakase/0.5.6");
            browsers.Add(new BrowserInfo { Name = "Kazehakase", Producer = "", ProductPage = "http://kazehakase.sourceforge.jp/ ", LayoutEngine = "Gecko", Description = "Kazehakase is a browser with gecko engine like Epiphany or Galeon.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1.3) Gecko Strata/4.4.1.1402");
            browsers.Add(new BrowserInfo { Name = "Kirix Strata", Producer = "Kirix Corporation ", ProductPage = "http://www.kirix.com/ ", LayoutEngine = "Gecko", Description = "Kirix Strata is a specialty web browser designed for data analytics.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; KKman2.0)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; KKman3.0)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; KKMAN3.2)");
            browsers.Add(new BrowserInfo { Name = "KKman", Producer = "Skysoft Co., Ltd. ", ProductPage = "http://www.kkman.com/ ", LayoutEngine = "Trident", Description = "based on IE", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (compatible; Konqueror/3.5; SunOS)");
            userAgents.Add("Mozilla/5.0 (compatible; Konqueror/4.1; OpenBSD) KHTML/4.1.4 (like Gecko)");
            userAgents.Add("Mozilla/5.0 (compatible; Konqueror/3.1-rc5; i686 Linux; 20020712)");
            userAgents.Add("Mozilla/5.0 (compatible; Konqueror/2.2.1; Linux)");
            userAgents.Add("Mozilla/5.0 (compatible; Konqueror/4.3; Windows) KHTML/4.3.0 (like Gecko)");
            browsers.Add(new BrowserInfo { Name = "Konqueror", Producer = "KDE e.V. ", ProductPage = "http://www.konqueror.org/ ", LayoutEngine = "KHTML", Description = "Konqueror is an Open Source web browser, the file manager for the K Desktop Environment and a universal viewing application.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1.6) Gecko/20071115 Firefox/2.0.0.6 LBrowser/2.0.0.6");
            browsers.Add(new BrowserInfo { Name = "LBrowser", Producer = "Xandros Incorporated ", ProductPage = "http://wiki.freespire.org/index.php/Web_Browser ", LayoutEngine = "Gecko", Description = "Firefox based web browser. As part of the Linux distribution, Linspire/Freespire.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Links (0.98; Win32; 80x25)");
            userAgents.Add("Links (2.1; Linux 2.6.18-gentoo-r6 x86_64; 80x24)");
            userAgents.Add("Links (0.96; Linux 2.4.20-18.7 i586)");
            userAgents.Add("Links (2.1pre18; Linux 2.4.31 i686; 100x37)");
            userAgents.Add("Links (2.2; Linux 2.6.25-gentoo-r9 sparc64; 166x52)");
            browsers.Add(new BrowserInfo { Name = "Links", Producer = "Twibright Labs ", ProductPage = "http://links.twibright.com/ ", LayoutEngine = "Proprietary", Description = "Links2is a graphics and text mode GNU web browser (to version 0.99 - only a text mode).", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows XP 5.1) Lobo/0.98.4");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Linux 2.6.26-1-amd64) Lobo/0.98.3");
            browsers.Add(new BrowserInfo { Name = "Lobo", Producer = "", ProductPage = "http://lobobrowser.org/java-browser.jsp ", LayoutEngine = "Cobra - (Java)", Description = "Lobo is an open-source all-Java web browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.1.4322; Lunascape 2.1.3)");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/528+ (KHTML, like Gecko, Safari/528.0) Lunascape/5.0.2.0");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1b3pre) Gecko/2008 Lunascape/4.9.9.98");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.1.2) Gecko/20090804 Firefox/3.5.2 Lunascape/5.1.4.5");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; JyxoToolbar1.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 1.1.4322; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729; Lunascape 5.1.4.5)");
            browsers.Add(new BrowserInfo { Name = "Lunascape", Producer = "Lunascape & Co., Ltd. ", ProductPage = "http://www.lunascape.tv/ ", LayoutEngine = "Gecko/WebKit/Trident", Description = "Browser used as the engine Gecko, Webkit or Trident.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Lynx/2.8.3dev.6 libwww-FM/2.14");
            userAgents.Add("Lynx/2.8.5dev.16 libwww-FM/2.14 SSL-MM/1.4.1 OpenSSL/0.9.7a");
            userAgents.Add("Lynx/2.8.6rel.4 libwww-FM/2.14 SSL-MM/1.4.1 GNUTLS/1.6.3");
            browsers.Add(new BrowserInfo { Name = "Lynx", Producer = "", ProductPage = "http://lynx.isc.org/ ", LayoutEngine = "Proprietary", Description = "Lynx is the text web browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.7.12) Gecko/20051001 Firefox/1.0.7 Madfox/0.3.2u3");
            browsers.Add(new BrowserInfo { Name = "Madfox", Producer = "Robin Lu", ProductPage = "http://en.wikipedia.org/wiki/Madfox ", LayoutEngine = "Gecko", Description = "Madfox was a web browser based on Mozilla Firefox, developed by a Chinese developer Robin Lu. 2005 the project stopped.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; MAXTHON 2.0)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 1.1.4322)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; MyIE2)");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/530.6 (KHTML, like Gecko) Maxthon/3.0 Safari/530.6");
            browsers.Add(new BrowserInfo { Name = "Maxthon", Producer = "Maxthon International Limited. ", ProductPage = "http://www.maxthon.com/ ", LayoutEngine = "Trident/WebKit", Description = "Maxton (ex MyIE2) - IE based browser. From version 3 uses two engines, Trident and WebKit.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Midori/0.1.5 (X11; Linux; U; en-gb) WebKit/532+");
            userAgents.Add("Midori/0.1.7");
            browsers.Add(new BrowserInfo { Name = "Midori", Producer = "TwoToasts.de ", ProductPage = "http://software.twotoasts.de/index.php?/pages/midori_summary.html ", LayoutEngine = "WebKit", Description = "Midori is a lightweight web browser based on WebKit.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; cs-CZ) AppleWebKit/532.4 (KHTML, like Gecko) MiniBrowser/3.0 Safari/532.4");
            browsers.Add(new BrowserInfo { Name = "Mini Browser", Producer = "DMKHO", ProductPage = "http://dmkho.tripod.com/ ", LayoutEngine = "WebKit", Description = "Fast and simple internet browser for Windows XP, Vista, 7", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.0; it-IT; rv:1.7.12) Gecko/20050915");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.0.1) Gecko/20020919");
            browsers.Add(new BrowserInfo { Name = "Mozilla", Producer = "Mozilla Foundation ", ProductPage = "http://www.mozilla.org/projects/browsers.html ", LayoutEngine = "Gecko", Description = "", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Multi-Browser 10.1 (www.multibrowser.de); SIMBAR={3C117E1F-85A8-4b43-816C-E78E9AACDE21}; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.30) ");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Multi-Browser 10.1 (www.multibrowser.de); .NET CLR 1.1.4322)");
            browsers.Add(new BrowserInfo { Name = "Multi-Browser XP", Producer = "Binh Nguyen-Huu", ProductPage = "http://www.multibrowser.de/ ", LayoutEngine = "Trident", Description = "Tabbed-MDI browser based for Windows.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.0; en-US; rv:1.2.1; MultiZilla v1.1.32 final) Gecko/20021130");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.4; MultiZilla v1.5.0.0f) Gecko/20030624");
            browsers.Add(new BrowserInfo { Name = "MultiZilla", Producer = "HJ van Rantwijk ", ProductPage = "http://multizilla.mozdev.org/ ", LayoutEngine = "Gecko", Description = "Mozilla based browsers", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("MyIBrow/3.0 (Windows; U; Windows NT 5.1; cs; compatible) MYIBE/2009000000 (Gecko/Khtml)");
            userAgents.Add("myibrow/2.2 (Windows; U; Windows NT 5.1; cs; rv:1.8.1.14) Gecko/20080001 My Internet Browser/2.2.0.0 20080913235045");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; cs; rv:1.9.2.6) Gecko/20100628 myibrow/4alpha2");
            browsers.Add(new BrowserInfo { Name = "My Internet Browser", Producer = "Media WebPublishing", ProductPage = "http://myinternetbrowser.webove-stranky.org/ ", LayoutEngine = "Gecko", Description = "My Internet Browser is a web browser based on Firefox.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("NCSA_Mosaic/2.0 (Windows 3.1)");
            userAgents.Add("NCSA_Mosaic/3.0 (Windows 95)");
            userAgents.Add("NCSA_Mosaic/2.6 (X11; SunOS 4.1.3 sun4m)");
            userAgents.Add("NCSA Mosaic/1.0 (X11;SunOS 4.1.4 sun4m)");
            browsers.Add(new BrowserInfo { Name = "NCSA Mosaic", Producer = "NCSA ", ProductPage = "http://www.ncsa.uiuc.edu/Projects/mosaic.html ", LayoutEngine = "Proprietary", Description = "NCSA's Mosaic was the first Web browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/3.01 (compatible; Netbox/3.5 R92; Linux 2.2)");
            browsers.Add(new BrowserInfo { Name = "NetBox", Producer = "Netgem ", ProductPage = "http://www.netgem.com/ ", LayoutEngine = "??", Description = "included in the cable modem TV Box Linux ", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 5.01; Windows NT 5.0; NetCaptor 6.5.0RC1)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; NetCaptor 7.5.4; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 1.1.4322; .NET CLR 3.0.4506.2152; .NET CLR 3.5.30729)");
            browsers.Add(new BrowserInfo { Name = "NetCaptor", Producer = "Stilesoft Inc. ", ProductPage = "http://www.netcaptor.com/ ", LayoutEngine = "Trident", Description = "based on IE", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/3.0 (compatible; NetPositive/2.2.2; BeOS)");
            userAgents.Add("Mozilla/3.0 (compatible; NetPositive/2.1.1; BeOS)");
            userAgents.Add("Mozilla/3.0 (compatible; NetPositive/2.2)");
            browsers.Add(new BrowserInfo { Name = "NetPositive", Producer = "Be Inc. ", ProductPage = "http://en.wikipedia.org/wiki/NetPositive ", LayoutEngine = "Proprietary", Description = "Default browser for the Be Operating System (BeOS).", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/3.0 (Win95; I)");
            userAgents.Add("Mozilla/4.04 [en] (X11; I; IRIX 5.3 IP22)");
            userAgents.Add("Mozilla/4.08 [en] (WinNT; U ;Nav)");
            userAgents.Add("Mozilla/4.51 [en] (Win98; U)");
            userAgents.Add("Mozilla/5.0 (Windows; U; Win 9x 4.90; de-DE; rv:0.9.2) Gecko/20010726 Netscape6/6.1");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.0.2) Gecko/20030208 Netscape/7.02");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.7.5) Gecko/20060127 Netscape/8.1");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US; rv:1.8.1.12) Gecko/20080219 Firefox/2.0.0.12 Navigator/9.0.0.6");
            browsers.Add(new BrowserInfo { Name = "Netscape Navigator", Producer = "Netscape Communications Corp. ", ProductPage = "http://browser.netscape.com/ ", LayoutEngine = "Gecko", Description = "Netscape was the general name for a series of web browsers originally produced by Netscape Communications Corporation, now a subsidiary of AOL.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("NetSurf/1.2 (Linux; i686)");
            userAgents.Add("NetSurf/2.0 (RISC OS; armv3l)");
            browsers.Add(new BrowserInfo { Name = "NetSurf", Producer = "NetSurf's Development Team ", ProductPage = "http://www.netsurf-browser.org/ ", LayoutEngine = "NetSurf", Description = "NetSurf is a free, open source web browser. It is written in C.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.7 (compatible; OffByOne; Windows 2000)");
            userAgents.Add("Mozilla/4.7 (compatible; OffByOne; Windows 98)");
            browsers.Add(new BrowserInfo { Name = "Off By One", Producer = "Home Page Software Inc. ", ProductPage = "http://offbyone.com/ ", LayoutEngine = "Proprietary", Description = "Small web browser with full HTML 3.2 only.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.5 (compatible; OmniWeb/4.1.1-v424.6; Mac_PowerPC)");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X; en-US) AppleWebKit/420+ (KHTML, like Gecko, Safari) OmniWeb/v595");
            userAgents.Add("OmniWeb/2.7-beta-3 OWF/1.0");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X; en-US) AppleWebKit/528.16 (KHTML, like Gecko, Safari/528.16) OmniWeb/v622.8.0.112941");
            browsers.Add(new BrowserInfo { Name = "OmniWeb", Producer = "Omni Development, Inc. ", ProductPage = "http://www.omnigroup.com/applications/omniweb/ ", LayoutEngine = "WebKit", Description = "Omniweb is a Web browser developed by The Omni Group for Mac OS X.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Opera/5.11 (Windows 98; U) [en]");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 5.0; Windows 98) Opera 5.12 [en]");
            userAgents.Add("Opera/6.0 (Windows 2000; U) [fr]");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 5.0; Windows NT 4.0) Opera 6.01 [en]");
            userAgents.Add("Opera/7.03 (Windows NT 5.0; U) [en]");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1) Opera 7.10 [en]");
            userAgents.Add("Opera/9.02 (Windows XP; U; ru)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; en) Opera 9.24");
            userAgents.Add("Opera/9.51 (Macintosh; Intel Mac OS X; U; en)");
            userAgents.Add("Opera/9.70 (Linux i686 ; U; en) Presto/2.2.1");
            userAgents.Add("Opera/9.80 (Windows NT 5.1; U; cs) Presto/2.2.15 Version/10.00");
            browsers.Add(new BrowserInfo { Name = "Opera", Producer = "Opera Software ASA. ", ProductPage = "http://www.opera.com/ ", LayoutEngine = "Presto", Description = "Opera browser is built on its core Presto.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.6) Gecko/2009022300 Firefox/3.0.6 Orca/1.1 build 1");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.7) Gecko/2009030821 Firefox/3.0.7 Orca/1.1 build 2");
            browsers.Add(new BrowserInfo { Name = "Orca", Producer = "Avant Force team ", ProductPage = "http://www.orcabrowser.com/ ", LayoutEngine = "Trident", Description = "Browser based on Mozilla Firefox. Developed by Avant force, the developers of Avant Browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/1.10 [en] (Compatible; RISC OS 3.70; Oregano 1.10)");
            browsers.Add(new BrowserInfo { Name = "Oregano", Producer = "Genesys Developments Ltd ", ProductPage = "http://www.oreganouk.net/oregano2.html ", LayoutEngine = "Proprietary", Description = "Oregano is a commercial web browser for the RISC OS range of computers.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (compatible; Origyn Web Browser; AmigaOS 4.0; U; en) AppleWebKit/531.0+ (KHTML, like Gecko, Safari/531.0+)");
            userAgents.Add("Mozilla/5.0 (compatible; Origyn Web Browser; MorphOS; PPC; U) AppleWebKit/528.5+ (KHTML, like Gecko, Safari/528.5+)");
            userAgents.Add("Mozilla/5.0 (compatible; Origyn Web Browser; AmigaOS 4.1; ppc; U; en) AppleWebKit/530.0+ (KHTML, like Gecko, Safari/530.0+)");
            browsers.Add(new BrowserInfo { Name = "OWB", Producer = "Sand-labs.org ", ProductPage = "http://www.sand-labs.org/owb ", LayoutEngine = "WebKit", Description = "Origyn Web Browser (or OWB) is an opensource Web Browser for CE devices, AmigaOS, MorphOS and more.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2) Gecko/20100206 Palemoon/3.6.0.5");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.2.3) Gecko/20100403 Firefox/3.6.3 (Palemoon/3.6.3)");
            browsers.Add(new BrowserInfo { Name = "Pale Moon", Producer = "Moonchild Productions ", ProductPage = "http://www.palemoon.org/ ", LayoutEngine = "Gecko", Description = "Pale Moon is built on Firefox. Pale Moon is apparently optimized for the Windows operating system.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; PhaseOut-www.phaseout.net)");
            browsers.Add(new BrowserInfo { Name = "Phaseout", Producer = "PhaseOut.net ", ProductPage = "http://www.phaseout.net/ ", LayoutEngine = "Trident", Description = "free web browser based on IE", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.4a) Gecko/20030411 Phoenix/0.5");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.2b) Gecko/20021029 Phoenix/0.4");
            browsers.Add(new BrowserInfo { Name = "Phoenix (old name for Firefox)", Producer = "Mozilla Foundation ", ProductPage = "http://www.mozilla.org/products/firefox/ ", LayoutEngine = "Gecko", Description = "Former name of the Mozilla Firebird browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; cs-CZ) AppleWebKit/527+ (KHTML, like Gecko) QtWeb Internet Browser/2.5 http://www.QtWeb.net");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/527+ (KHTML, like Gecko) QtWeb Internet Browser/1.2 http://www.QtWeb.net");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US) AppleWebKit/527+ (KHTML, like Gecko) QtWeb Internet Browser/1.7 http://www.QtWeb.net");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; cs-CZ) AppleWebKit/532.4 (KHTML, like Gecko) QtWeb Internet Browser/3.3 http://www.QtWeb.net");
            browsers.Add(new BrowserInfo { Name = "QtWeb", Producer = "QtWeb.NET", ProductPage = "http://www.qtweb.net/ ", LayoutEngine = "WebKit", Description = "QtWeb is a lightweight, secure and portable browser. QtWeb is an open source project based on Nokia's Qt framework (former Trolltech) and Apple's WebKit rendering engine.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux; cs-CZ) AppleWebKit/527+ (KHTML, like Gecko, Safari/419.3) rekonq");
            browsers.Add(new BrowserInfo { Name = "rekonq", Producer = "Andrea Diamantini ", ProductPage = "http://rekonq.sourceforge.net/ ", LayoutEngine = "WebKit", Description = "rekonq is a KDE browser based on Webkit. Its code is based on Nokia QtDemoBrowser, just like Arora.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("retawq/0.2.6c [en] (text)");
            browsers.Add(new BrowserInfo { Name = "retawq", Producer = "Arne Thomaßen", ProductPage = "http://retawq.sourceforge.net/ ", LayoutEngine = "Proprietary", Description = "retawq is an text web browser for Unix-like operating systems.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X; fi-fi) AppleWebKit/420+ (KHTML, like Gecko) Safari/419.3");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X; de-de) AppleWebKit/125.2 (KHTML, like Gecko) Safari/125.7");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X; en-us) AppleWebKit/312.8 (KHTML, like Gecko) Safari/312.6");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; cs-CZ) AppleWebKit/523.15 (KHTML, like Gecko) Version/3.0 Safari/523.15");
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.0; en-US) AppleWebKit/528.16 (KHTML, like Gecko) Version/4.0 Safari/528.16");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X 10_5_6; it-it) AppleWebKit/528.16 (KHTML, like Gecko) Version/4.0 Safari/528.16");
            browsers.Add(new BrowserInfo { Name = "Safari", Producer = "Apple Inc. ", ProductPage = "http://www.apple.com/macosx/features/safari/ ", LayoutEngine = "WebKit", Description = "Safari is a web browser developed by Apple Inc.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1b3pre) Gecko/20081208 SeaMonkey/2.0a3pre");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10.5; en-US; rv:1.9.1b3pre) Gecko/20081202 SeaMonkey/2.0a2");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; rv:1.9.1a2pre) Gecko/20080824052448 SeaMonkey/2.0a1pre");
            userAgents.Add("Mozilla/5.0 (BeOS; U; BeOS BePC; en-US; rv:1.9a1) Gecko/20060702 SeaMonkey/1.5a");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X; en-US; rv:1.8.1.13) Gecko/20080313 SeaMonkey/1.1.9");
            userAgents.Add("Mozilla/5.0 (Windows; U; Win 9x 4.90; en-GB; rv:1.8.1.6) Gecko/20070802 SeaMonkey/1.1.4");
            browsers.Add(new BrowserInfo { Name = "SeaMonkey", Producer = "Mozilla Foundation ", ProductPage = "http://www.mozilla.org/projects/seamonkey/ ", LayoutEngine = "Gecko", Description = "The SeaMonkey project is a community effort to develop the SeaMonkey all-in-one internet application suite (Web-browser, advanced e-mail and newsgroup client, IRC chat client, and HTML editing made simple).", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X; en) AppleWebKit/417.9 (KHTML, like Gecko, Safari) Shiira/1.1");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X; ja-jp) AppleWebKit/419 (KHTML, like Gecko) Shiira/1.2.3 Safari/125");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X; fr) AppleWebKit/418.9.1 (KHTML, like Gecko) Shiira Safari/125");
            browsers.Add(new BrowserInfo { Name = "Shiira", Producer = "Shiira Project ", ProductPage = "http://shiira.jp/en ", LayoutEngine = "WebKit", Description = "Shiira is the open-source web browser that based on WebKit framework.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; SiteKiosk 6.5 Build 150)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; SiteKiosk 5.5 Build 45)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows 98; SiteKiosk 4.8)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; SiteKiosk 7.0 Build 248)");
            browsers.Add(new BrowserInfo { Name = "SiteKiosk", Producer = "PROVISIO GmbH / LLC ", ProductPage = "http://www.sitekiosk.com/SiteKiosk/Default.aspx ", LayoutEngine = "Trident", Description = "SiteKiosk is a special browser for public terminals/kiosks.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1) Sleipnir/2.8.1");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; InfoPath.1; .NET CLR 2.0.50727) Sleipnir/2.8.4");
            browsers.Add(new BrowserInfo { Name = "Sleipnir", Producer = "Fenrir Inc. ", ProductPage = "http://www.fenrir.co.jp/sleipnir/ ", LayoutEngine = "Trident", Description = "IE based browser", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Q312461; SlimBrowser [flashpeak.com]; .NET CLR 1.1.4322; .NET CLR 2.0.50727; .NET CLR 3.0.04506.30");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; Trident/4.0; .NET CLR 2.0.50727; SlimBrowser)");
            browsers.Add(new BrowserInfo { Name = "SlimBrowser", Producer = "FlashPeak Inc. ", ProductPage = "http://slimbrowser.flashpeak.com/ ", LayoutEngine = "Trident", Description = "IE based browser from FlashPeak Inc.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_5_6; en-us) AppleWebKit/528.16 (KHTML, like Gecko) Stainless/0.5.3 Safari/525.20.1");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_5_5; en-us) AppleWebKit/525.27.1 (KHTML, like Gecko) Stainless/0.4 Safari/525.20.1");
            browsers.Add(new BrowserInfo { Name = "Stainless", Producer = "Mesa Dynamics, LLC ", ProductPage = "http://www.stainlessapp.com/ ", LayoutEngine = "WebKit", Description = "", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X; en-us) AppleWebKit/125.5.7 (KHTML, like Gecko) SunriseBrowser/0.853");
            userAgents.Add("Mozilla/5.0 (Macintosh; U; Intel Mac OS X 10_4_11; en) AppleWebKit/525.18 (KHTML, like Gecko) Sunrise/1.7.4 like Safari/4525.22");
            browsers.Add(new BrowserInfo { Name = "Sunrise", Producer = "", ProductPage = "http://www.sunrisebrowser.com/ ", LayoutEngine = "WebKit", Description = "Sunrise is the open-source web browser that based on WebKit framework.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.0.10pre) Gecko/2009041814 Firefox/3.0.10pre (Swiftfox)");
            browsers.Add(new BrowserInfo { Name = "Swiftfox", Producer = "Jason Halme", ProductPage = "http://www.getswiftfox.com/ ", LayoutEngine = "Gecko", Description = "Swiftfox is an optimized build of Mozilla Firefox.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (X11; U; Linux x86_64; en-US; rv:1.8.1.6pre) Gecko/20070730 Swiftweasel/2.0.0.6pre");
            userAgents.Add("Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.8.1.7) Gecko/20070919 Swiftweasel/2.0.0.7 ");
            browsers.Add(new BrowserInfo { Name = "Swiftweasel", Producer = "SticKK", ProductPage = "http://swiftweasel.tuxfamily.org/ ", LayoutEngine = "Gecko", Description = "Swiftweasel is built from Mozilla Firefox source code, and not burdened trademark graphics and logos. Is optimized for several architectures, and is only available for Linux.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 1.1.4322; TheWorld)");
            browsers.Add(new BrowserInfo { Name = "TheWorld Browser", Producer = "Phoenix Studio", ProductPage = "http://www.ioage.com/ ", LayoutEngine = "Trident", Description = "TheWorld Browser is compatible with Internet Explorer and it can run in most Miscrosoft Windows OSs. It has multi-threaded window frame, which can avoid web page being out of response.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; Tjusig 2.40.164; SV1; .NET CLR 2.0.50727)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; JyxoToolbar1.0; Tjusig 2.40.164; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 1.1.4322)");
            browsers.Add(new BrowserInfo { Name = "Tjusig", Producer = "Lukáš Ingr", ProductPage = "http://www.tjusig.cz/ ", LayoutEngine = "Trident", Description = "Browser based on IE. Its development was terminated in 2002.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; TencentTraveler )");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; TencentTraveler 4.0; .NET CLR 2.0.50727)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; TencentTraveler 4.0; .NET CLR 2.0.50727)");
            browsers.Add(new BrowserInfo { Name = "TT Explorer", Producer = "Tencent ", ProductPage = "http://tt.qq.com/ ", LayoutEngine = "Trident", Description = "TT explorer (Tencent Traveler) is a web browser based on IE, and developed by Tencent, the Chinese Instant messaging & messengers provider.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; JyxoToolbar1.0; SV1; UltraBrowser 11.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 1.1.4322)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.0; UltraBrowser 11.0; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET CLR 1.1.4322)");
            userAgents.Add("Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.0; WOW64; Trident/4.0; UltraBrowser 11.0; GTB6.5; Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1) ; SLCC1; .NET CLR 2.0.50727; InfoPath.2; Media Center PC 5.0; .NET CLR 3.5.21022; .NET CLR 3.5.30729;");
            browsers.Add(new BrowserInfo { Name = "UltraBrowser", Producer = "UltraBrowser.com, Inc.", ProductPage = "http://www.ultrabrowser.com/ ", LayoutEngine = "Trident", Description = "UltraBrowser is a web browser built on IE for the use of portal services ultrabrowser.com", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Webkit/1.1.8 (Linux; en-us) Uzbl");
            userAgents.Add("Uzbl (Webkit 1.1.9) (Linux)");
            userAgents.Add("Uzbl (U; Linux x86_64; en-GB) Webkit 1.1.10");
            userAgents.Add("Uzbl (X11; U; Linux x86_64; en-GB) AppleWebkit/1.1.10");
            browsers.Add(new BrowserInfo { Name = "Uzbl", Producer = "", ProductPage = "http://www.uzbl.org/ ", LayoutEngine = "WebKit", Description = "Minimal browser for unix systems.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("w3m/0.5.1");
            userAgents.Add("w3m/0.5.2");
            browsers.Add(new BrowserInfo { Name = "w3m", Producer = "Sakamoto Hironori ", ProductPage = "http://www.w3m.org/ ", LayoutEngine = "Proprietary", Description = "w3m is a text-based web browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; cs-CZ) AppleWebKit/532.4 (KHTML, like Gecko) WeltweitimnetzBrowser/0.15 Safari/532.4");
            browsers.Add(new BrowserInfo { Name = "Weltweitimnetz Browser", Producer = "Philipp Ruppel ", ProductPage = "http://weltweitimnetz.de/software/Browser.en.page ", LayoutEngine = "WebKit", Description = "Weltweitimnetz Browser is a fast, secure and user-friendly webbrowser using webkit and qt.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Macintosh; U; PPC Mac OS X; en-us) AppleWebKit/103u (KHTML, like Gecko) wKiosk/100");
            browsers.Add(new BrowserInfo { Name = "wKiosk", Producer = "app4mac Inc. ", ProductPage = "http://www.app4mac.com/store/index.php?target=products&product_id=9 ", LayoutEngine = "WebKit", Description = "A full-screen kiosk browser.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("WorldWideweb (NEXT)");
            browsers.Add(new BrowserInfo { Name = "WorldWideWeb", Producer = "Tim Berners-Lee ", ProductPage = "http://www.w3.org/People/Berners-Lee/WorldWideWeb ", LayoutEngine = "??", Description = "The first web browser. Written in 1990 by Tim Berners-Lee.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.0.9) Gecko/2009042410 Firefox/3.0.9 Wyzo/3.0.3");
            browsers.Add(new BrowserInfo { Name = "Wyzo", Producer = "Radical Software Ltd. ", ProductPage = "http://www.wyzo.com/ ", LayoutEngine = "Gecko", Description = "Wyzo browser is built on the Firefox wits BitTorrent and other addons.", UserAgents = userAgents });
            userAgents = new List<string>();
            userAgents.Add("X-Smiles/1.2-20081113");
            browsers.Add(new BrowserInfo { Name = "X-Smiles", Producer = "X-Smiles.org", ProductPage = "http://www.xsmiles.org/ ", LayoutEngine = "??", Description = "X-Smiles is an experimental XML Browser written in the Java", UserAgents = userAgents });
            return browsers;
        }
    }
}

