-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: cipa
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__migrationhistory`
--

DROP TABLE IF EXISTS `__migrationhistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `__migrationhistory` (
  `MigrationId` varchar(150) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `ContextKey` varchar(300) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `Model` longblob NOT NULL,
  `ProductVersion` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__migrationhistory`
--

LOCK TABLES `__migrationhistory` WRITE;
/*!40000 ALTER TABLE `__migrationhistory` DISABLE KEYS */;
INSERT INTO `__migrationhistory` VALUES ('201901091010371_InitialMySQL','CIPAOnLine.Migrations.Configuration',_binary 'ã\0\0\0\0\0\0\Ì]\›n;íæ_`\ﬂA\–\Â\‡å\Â$\»\‡L\‡\Ã¿\«I\Œ\'^;1ˆN†%\⁄nL´[ßªe$g±O∂˚H˚\n\À˛\ÁOˇö›írÇ\0Å\’$ãdÒc±HVˇ\Ô˛˜\Ï\Ô_7Ò\Ïâfyî&Ø\Á\œNN\Á3ö¨\“uî<ºû\Ôä˚?ˇ<ˇ˚\ﬂ˛˝\ﬂ\ŒﬁÆ7_g∑mæe>V2\…_\œãb˚j±\»WètCÚìM¥\ \“<Ω/NV\ÈfA\÷\È\‚˘\È\È_œû-(#1g¥f≥≥\Î]RDZ˝`?/\“dE∑≈éƒó\Èö\∆yÛù•\‹TTg…Ü\Ê[≤¢Ø\Á\ÔØ\Œ?%¢Ñû‘ô\Á≥Û8\"¨!74æü\œHí§)X3_}\…\ÈMë•\…\√Õñ} Ò\Áo[\ Ú›ì8ßMÛ_ı\Ÿm{r˙º\Ï…¢/ÿíZ\ÌÚ\"\›8|ˆ¢a\ÕB.\Ó\≈\‡y\«:∆º∑å\…≈∑≤\◊_\œ\œW\ÕW\—&˝m¢ÇÒ@ÆÛ\’Eúï˘6üHÖöıY~\Íê¡\0T˛câª∏\ÿeÙuBwEF\‚üfWªª8Z˝ì~˚ú˛ã&Øì]Ûçe\Õei\¬ˆ\È*K∑4+æ]\”˚¶ö\ÈØ\Ÿnõ\Œgs˛∑˜¥àûîºgπ∂Æ,TQ\Õ&6-\Ê≥KÚıMä\«\◊Ûü\Á≥w\—W∫n7\ÿ˙íDl±\"E∂c??≤Œíªòv\Èm\’]õ\ÎjI”òíƒô\Ãk\“tM\È}Rºx\ÓLáï¢\Ÿâ\”\ƒ\ FuHr$ıë<EN%¢\Õ(]”∏J\Õ£m-N™îeWa\ﬁv\·]ñnÆ”∏-´\‰X~&\Ÿ-XSm∂õtó≠ZZv?øà∂4bslqôC™Lm4öIi7ûj˙Ÿ¢óZI\“p\‹E~TEˆ*5|Ö¿\ËÛÖã\n‹êo`¿x)/†t¯sKWÏ∏ó0oŸ∑\À(˘£.IU\◊ırü\√\»MëfÙWö–åt}E\n∂1\Õ\Ícö\ÿUFæJï\È\À‹≤e.µ,)<º∏óß∞yaö\≈$YGkR8\Œ\‚ÆÿûfÒª]≤bë,JﬂØ≠\Êf=\≈\ﬁ\∆4ZèıB™p\nîK-û¢\ §Y\Ÿ\√vtwi\Î}\√h}f;g¡¿\Ê#µVå\Ì\\\„\Zì_\”mñ>¶iÅSé\À\⁄\Â\\r\Ô\Áù>ß¢k≤ª\Íä›ò}h\“z\Í9\ﬂn5Ui+ê≈µ}\ÿ¡6r\ÈH;\·J[ëlÆ\ÌΩMD\Á.S`à)JÀ§\‰A*5Ñ?q\ÀS8jÖ\€_åΩ_”äø&π\„$∞\nb=©ÀîW∂\0\Ô˘ÀóVZû´ÙÑ\'r0Å)k+ñÚ\’k:u\·2ÉöB?&ç∂æ_i^<üŸ°\”qV0ÂÇºg¢t∞∫QízGWè\ÏGR\0\‰¨fzA∂\ƒisQócL`ö\Œ¿c¥ö\‘Mƒ¶ äÚ\ÿ€îeà\ﬂ\≈¡N\‡¯ı=Ñ∫\"K\nçFc≠Nï\„u^^2hõ\»gSõÿß¢M‰≤∏6ë[çÙ|3™\Õ\‰\”—Ü\nô\\õ\⁄\¬G\”\»6ã⁄º:mXì\Ï⁄§´å¸û\Ê˚a\ÓU™Ùe∑:ÙçSSu\»‚™Ñ^”ú≠\’Nhaó⁄ÅIm\'ñGi-ö—µÕúò\—7óKÒ.Ù>á\Î∏wh\\ìVw=•\¬dë\”*ºvød$Yi6u:4\“j*∏ë≤⁄Ñ4ãöì\ŒTŸ´\∆\‘4\⁄OmÇñÒë\ŒM>¶*T©N?üé¢;E$Ø§\◊TöH\È3\›l\ŸêuükN%îÅá˚Æä>\—U\Í¥}yª!¢QT\‰•|r”Ñd§ÖbûAª¢ñC.º.ÛcOdú\€\‚D&˜Kªπ\Ì5≤\Œ\\X(∫ßqV\œ\Á\Õc\‚à\›e|uón£HmY^W\\caJ8\·uAWû¿∫.	\À\’.&è\'>Qi4†\Õ6£πQ\Z4?˛2\ ¸¯ê>Ùó\…a\‰-¿$∂\ﬁj\Ô\€CTrûQùV§éÚ\–\Î|ΩâÚú8yïe?íÚ>\Ÿ\Á¿¨Yìptü®\⁄<Ç21%_\·\Îﬁ§wôºûß\Ì≤0\‹m\ÓéøDl\÷≥ì\ÊÅ\Œ·ºØ\‰d\≈\‘psg}&◊äC[ª|pCõdm+\€<\Œ\‰ﬁ•\»àîg)\»t∞\…r6›ùßí\◊ı¢ù&∑\Ÿ`◊©Z7Y\\9l∏ó-\œ5§vÒ\ﬂ\·;\Ÿ6q\Ï†ab™\È\ƒk§˝âM;5ú\Œl\ÍB\–=ù\ÕY\Õ5˘ù§7\È*\"!.\Ô{ï/˘Ns–à¥>w∫ •©GrÜA\Á\n\r76ÖˆÑ\¬Fyta ùÛ\‘\Î+ö\›kı∂\Á£T´≥\…0(r4y‘©\—aπZ]\”’é}%+\ÌMxhCçf\÷êäA&0BôÉ5Ñ1\ÂHVdîgê\ÿRî;\œCé≤!⁄∏§\≈j\Õi˜=ê˜\"\Í`®Ë´æk\‘bT\’˜sºiît\'œõ™\ÃT\Ÿ;\Ë^\”¡HàZ≠°u\Î,oD\Ïu;1° g\ƒ8±s@\◊\‰I$.\“\Á\Ô\‘?°<¨l|[\næø\ZˇT\ﬁ\”,\◊\⁄j]^ú£vø\Ï<\…\Í\ƒlè|^\‚-\¬\Í\√wAVó;6qv¥2\Èá\\ó:\œ gì2h6\"Vg°$Ñ\”™°}ÉeFo\‘\È&3˙r˚5~Éß˛h\ÊrSN\ÿ\…-ÙJ	qMI˝^9_πﬂëñü“º0óıö\€\Œ\ÃÚ\‹\—\ÿ8;ô\—[WgÇ\€V˝ØkYmÙ6dNÀ¶\œn3[.}4Û6*±\ÌU\“àÜ„≥ü9\ƒ{©I\Ãk\\ô\Z\∆\ﬁ∆±\÷08nh∏EéGlç\Ê*}à!WH3ï@øÜ34\œ\–$^+ y\Õ3zÚx≠}úéÀ¢\◊˚qN<\‰ú¯\≈^Œâ«ë\ƒoì5\Õ\ËjÑ˚Myèÿ±9\Ÿt€≤\…Lû\Ë\Ë&ˆv≠Ôöì\›D]\Ë\«D\rßú\r\ƒg(; y≤ù\‰ç©dvZb¥†\r`\Ãiµ≠<3á∫o*\÷òg\Î‘é∏jô*%\·\ÌÚ¥H≈£]∂îõjì\Í\–`XÉ\Í\‘A\ \€2x8 µ•~H4Ω=\…t{[W ◊ùQû\Ô\¬\'à6\Àtïå\Í\ËT\Óù.\“z#VÖªMÉ{≥wt\…Ic3:\«YƒÜí°≥<)\€√ãG5™\ÿ¶\⁄\Œ\Ïb£\÷x\Ï\‚¨2L≤Åã∂l®Xk\ÿ ØÙ\‘H∫≥º\ÎI+±\≈J˛§T\¬∆õ©\ÊI\’¸Ç-AQR®\‡àíU¥%±UW•\“í≤ùÆ.9\Â\r\›“§pVL±oõu\—U(\·\ﬂƒ≤≥á%=\ƒ†ù,\"xˆh\‡b\Êöp`SÉ;\ﬁTP{\·\Õÿ§¡£\rñ¿cÒ⁄£\‘8^ì7}X\‚ºa»≥\r˙\÷\√uhèu€∏újçÚ\€\Ív-≤ÅÄ!f≠\◊Më=\Ó\Ì\∆ro˝ò`\0°\ 0\Í\‚ñı\–\Î∫cØ8h¢ù\Ÿ`:ê∫Äwo\"Ug\√—ÄâKÉé6£ÜP}ôn/¡∏6¡6N\…(í™|*º\0å¥Ø∫\Â\ Å\"\∆p\—/8h0l\‡`C])–åHˇÙ\‰$(é¿\÷ÿå)\Ô\›J è\Ì’áo\Ÿ\ÎJ\∆E¥4-8PxK\„J¶\≈\”’ÄPB·∞é@Fs^´ô\ \„\0≠ò\0NH\Ïl\‰MÅ$˙\—,x\Ïï$S¯\È%}W\'êVzV\–\÷\'\‰ ä\ræ\÷[¥˘\Œ-\›^b\È|L\Ì@Npi\⁄2™4<>H)\—\Ë:ÖÜK\‡V©ˆ™\œa˘CΩÆ]1\Í)®\€6\€Q\Âæ\“\n\Ì∫\Ó\Î\‚\Ôòhi\Z1—æD\√dá•6Œù~ÒW\\§-F˜ó1V\nZHUª\ \‹\ƒwx\ÿa\röV3¿\∆\‡Xd9™\ F\Ó\»q´Ç\n5)\‚Y\ÿ¯Èè•\Z\‡≠ÿÉPy\Ïp5\“0i/xí\‹g±\·\∆|i˚°æ§ï@ÿõR\”\›V¿-8¸\€	x,ú€≠Ò˙?ÿìd¡±Zã,\≈or Rï@vSÆ¢P&X6!F:\√w\„û\n0í∞nò1ß`<≠oΩÑ∞7,<\Ó»ºA∑a¢µg1â\…k\€r\ƒ5¢h0öˆ*ñ\‡vL$ú`ôàj\ÁÇöï\È&~\⁄*\»%¯ ñ◊Ü¡É	¶Kb\‰\È¨ \ﬂ\◊U1X˝D2f®}\Â{Ω.`c¨ã\n–è3\√?∫\'”¶Z\‹Ò6L$ú¡«≤∏+Ål\∆[å\‚IB¯\”-Ò(\‚\Îw\¬¡\ƒw¥a°û\—ÿêõ›§˚°W\„y\ÿC\À¸^\‚T¢\ ‘íâñâÒ\«\"∂∫fw\Ô&=xÖ2à˛§æ]\…\—\Â¸Ò\«6pQ\⁄1±.•◊æ~éK˚1>ê=M±1\«\›Nπ+\›÷´\€ﬁöå\‘°~\∆H\«&\¬\∆\0˚\Í;Æ\Ô@Üw\‘;\ÿ≠\’\n\‚S<\Ÿ-;“Ä©¡sú∑\Î¢ﬂ∂iå%\'\Ó ∏]øMNè-ú†˙\'ç¿O˚∫ßs@¨=_YôÇï†Y≠Ù<ÜÇ¸|\…i„©ú7N\—Ú\Ëó\‰nh\—:xKæò˘|\÷˚\⁄bÉ\n¢Dös B ◊î\‚•˚]é\“\‡¸#\rt¯7\Œ2\Ë5 Jfóëºsã“ë\€\‘˚\‡\n=D¡VI4èﬁ´¿XürÒ˙,*ür)ZKwàÑ\‰/`†$ú´\ƒ4Å\rU¶to•®lA\"\ $˙óTùŸûCáﬁ•0\”\'\”\Ï™\Ï&@n\√&\nÖ[§%∑6’ãè§Å4⁄´•\Í\»#G\—Àü%(uõ\⁄\\3ù\‘c\’nWQC∑,*å\ÍïÑ¨¥*$\⁄)ç>ËäçXU\‚\\ÄÚU\…%ë\Êñ*IÍ´°f\\f~0iCòÜÆß˝“£,\Ã÷Å8b¿\⁄(1b!r¬ÇKxÙ\0ÄQñ°ÑÓôÉ\rp=ñZ\r\œ\ÃÒFfõ¡;\‡ùã?ª\–WKèvÆ√òÜ†a®•;Pâ:R\Ï¸úöº°¡\„0¿›á\ÎE/ü5\Ã\—x@è\∆\ﬁWb\Í\À+∂Ú\Ê\Âª\ﬂ,v∫\ŒC˛ªâN]\‘gIC√∫ÆÒNö˚ß˙0ˆH\Â(q\⁄g∞i¡9Mj¶\ÊZ	bpÆÙùÄ;•ë≥\Ã¿ûãVb\„(Ù\ƒ\‡\»ıF\‹hòcpKnÄ\Ô\Z™2z∑â\Á2\Zˇ6Æ#˝˛D\√ùGõ%ü}&íÚ%0ç¥\ÓY\"Ú1-˜›ÜO7Ö0ó,∂úB›ÆS?¿d\ÈÚ9Ú–ô#ü [w[\‘\'µ\Ï—ªa\›Bêv5;u;û°G\„\Õ.\Ë\›v=™ óí\”\ÃPLIn2¸f≠;\…\Ã˘94ï:è°\Ìà\œ\◊\Ó[#>/è±V!Ò\·5§\Ô†\ÈÆ\⁄j\Ÿl◊Ωﬂ≤q\Óxz\Ó\n\ÓΩ\Œ^\Èb/s¢;30±Ä∑PˇÜ≥DùE∑Æ:px∞d\Z§Ä\÷\∆\Z\›∑JUr\–.\ŸWø-ë\«gçfÛ´±R{†\Ÿ\0ª0bäM0Ù™ñ\ ì…≠\–|ç\—-\◊ÒÙ[\√\rçù\Ì8\"D}\ K\œ\’jmø`7:îÇ©\Ë;`¸Ωï!vêB_å6ê\\ü†\rõåfè\„ G5\ \”H\ƒrî™ÌûØLQ≠ı8J¸ç\œ£\Â˘\‡\\@kx\Zk(¶g¸÷µªj“ù`\∆f\„`By+A\√\„\ﬁ≥üÚ\Ê¡$˚]\ÈeúÄ	\ÿl\—»∑Û¢ŸèÒM\”Ò6>{g•“•ù-nVètCögñeE∑\Â\·e<øM∏$\€mî<\‰}\…\Ê\À\ÏfKV\Âç…üoÊ≥Øõ8\…_\œãb˚j±\»+\“˘\…&Zeiû\ﬁ\'´t≥`RoÒ¸ÙÙØãg\œõö\∆b%\Ã,Ÿ¶¶´â\È¢\‰ÅJ©ï\…}eyQ>\ŸvG\ \ËÙÎçí≠±\…Ana\€J0≥uº⁄ãŸ∂d˘ws¶<A`∏\Ï\Ÿ˘éı∞|O¶\Í,Ön\Ì0\nå\∆Õä\ƒ$”Ωsë∆ªMR\'¨™Ñ\Â#\ÿ\≈¡\ÊâQ,86Nßº¥l\ÔVyRø±\Ô\À4e“ë´.√üHúB4£6qIZ>∫6ıº/®¥VKÙl!ç≠•ÖÇ%ib\À µÇp#%Ü\·îxhE\ \È1\n¡ÛÄ\ _\∆\„jo#\Á\ŒYMŸ£î\0’´& Ñ⁄®è§	ïo–®Ñ ØˆÑößOx2OıßÉÅ°ˆ\œÖ\Ëa´\n5e1\÷J\—ix\ﬂs\«\—πF\Ìn\ﬂÄõbnP8\—05É5Ö≥)?\÷\È\Àü¡	c•Çó*0kæ\“$ªô0®¨p˝®\'fΩ9~D_¶™ºﬁ§ò∏\ﬁ\‹4õlÄ!;òBKé£ÚöM\Íá\Êõ=ïr\ÔÛ>âVëDâ\Õ≤åö7r\Ô\Ë\Íë4è[*$\ÔπDgt\◊«ñ∂a\'i¡\ŒP π\√<\œLDπS2Älé˚Dö∑\'˘\0\’\r∏bì≤>¨8%°#hõ		óÛó\À@ïIÑú\·˘&\"yu&.\Õ ˆyπ≠øOÇ=\…˛-ÄhÅ>î∞7P∂\◊K\√P	_óY¿+8\Ó2QB\Z˚Ñ}?<π—õ}$≠]´\≈X £áIí>\Á¶\√\’\œ\–ÀÉ\‰Bûë8\rÒ.C≠±≥hm\ÈqÜ˘íY¥\⁄\≈D0êt\Ï6ááé\‘\ﬁ\«@Z\Êç\…\ÈÉ|T◊ü∫F2E÷ü\ÏiúgT\‚\n©æ∏\È∂\Á\Î⁄Ö\n\–lIó\‰FÚ#…ª∑\‡¢	ó\Ëp\–V˝*\‰LfÜSkáˇ!Åûqí7\È]&°)Ø?9H∏\«\›\Ê.Q∫WÙüF\∆uWçµ`¯˙\‘F\∆Jé´q\\ì\ﬂIzS^)JÉ$$\Ã0i\’]Ü©ıv&¥\‰ò\"u∏`ø¢ŸΩ<\r∑Õ∑=Ü\›\–\‰Qˆy˝\…U˛]\”’é}%ÿ°Z∆ß§U´˜`*V\Â\À>HÕÇ)Läè\⁄!_†¯\»\Ôq\0;˙Å◊∞†Ä\Õ=,Rp¸≠\Í0ô\‰¢¯\Ïiho\Ã\«[øI≥öyù\—9>´Gç{\¬ASÀ™œµ\Á€ëRyo\Ó¸\0\Õ˝±Mq0Eπí∂ï\€C\√m\Î0æM0?cÖ˜	\Â1¡\\|ƒ∏(3\Ó\”ût¯É_{ïx∫¶$é~ØÇX)à\ ˙47¢\Âß4/ ö\€.\È`Äò\›ÉõÑ\»tfìB\œ\·êry\œg\ŸÛÅ%z¯êï	\À=}¯q~\Èq~Y\Z\–5Ó£ä	\›\ÏVäÛ9\⁄æ\√C∑é∆ä{eúo\À0Ü˙\ÌX\».M\Ÿ\Ôi«à\“H\÷4£++\›WAŸ£8€°∞•dõ&9y¢≤\‰¬ùw\À¿\ÿ\∆`\«\„\0+9.xGYˇ\¬ \Ë-\”\◊\Óò\÷\0^LQ9\—˘R\…›§|O\–\Ï#4\√f\Õ\—úx\—q\—yEd˚\Â-q3X>\œÛù\“~t\0cñ\…¨æJ¿ú\√\0Ö\Ît«éùn\ƒ\À‚êú#D_Gæñãneq-\À\ÂFÆ_ë\ÎΩ\“sS\—E\‡xX*ó\Á=æêî¸\Íö\·\—B4∫ª\”^jπÉ/\Î\⁄\'˚≠∫7;\ƒ\¬D\\*ÅòÉ\¬Y…å\’D	0¸¯õ>n√Ø	eb\ŸJ\◊Kº!\0P¸ó\Â,ù¥iætø;ˇ\Â\∆wXpjÆ∫V∫(W]\ ?fŸô∏\Œ2ü±∂?E\Î ë¯\€\ÕoÒIô~R˝yGL¿ı9.I\›3\Â\Ís˙/öºûˇ|r:üù\«\…kwÚ\∆M˙ï¸6Äï\ﬂÙ≥•\ﬂ4]orqw\Ô\ÎíJûØçÑ[\ﬁ\⁄\’_\Áx|ˆO™¿≠\‰˛MΩR@∂\Ágπ∫3	ïbMu\ÿ\Ï\‰âd´GíØ1ºg[ªØØ\ÁˇUï~5{ˇüKû¿O≥O\ŒW≥\”\Ÿ\œgó\‰\Îö<èlDÁ≥èª8&w•ª˛=âs5D∏‘ÆÆCuì\Ó\“4v¶!¯E\◊t¢véd@Whr≤ˇ≥-%^\–\‚zw\≈uæR\—\„\0\0\Î\Œ!ﬁº\”N+0/¶ N<óMõ«ûãCõı¨lñ\œ‘©X<p˙UN\Œ ç\ÍÖâFá>qa;l\’	t: :í∑rïC,\–!ñ\·\Í8¶rG\‹\Z\"ñ\‘\–—πn\r˚\≈&@yD{ï\—UîW˙À©s\rΩ\◊3º0™¯uÜ\Ó!<\Â2Rç^µ\√¯ï2ñqo}Eär\'_™“¥jº3˜B\"6$nÜÿÆ]>∑uy÷¨\Ï\œ_æÑ?¯â\›cá\\\ÎòÏ∫¨\◊Âñª\‰∑~öΩœø$\—o;ñ˛ô1ZZŸüΩtnù\‡\ÏTP)>œ∂\‘mV`\—\n\ƒO‹óe±I\Î–Ü\Œ[⁄°¿\ÿ>á\∆\÷Oäpé\÷^ú\È\ \‡N\Îf9å9/úôc/tÄ\'\‚ß9Æ\Í8èz{ÅRπΩVe›Ñ\ \œsüÛ\÷ˆ÷≤˝ÑÙ4\‡\Î˝JΩfX[\‹~ÇY\„rµ>˙5T\ÿ\÷\Ë\"/\râ55N\–v\ÃTw`fFJ\n\ÈL‘ü—∏OtyÙ´aû[zãp¥¿˘6;üÒ¨ør¸\Ë\≈FxÖPæ6sëop#¡&4vˇ\‚é\›∆ñ\—~(¥¨6âÄ”µ§ıÑ¥°YF%)YHÜ\‘\‚?\Ôê\ƒ[6\r/ûù˙\Ó;ZpØ≈ø.<D∑n\\«ál\ Q\ﬁõ÷Ñ\„4y∏ã”ªPª{\»%˚\–Um¡¶\⁄JC6$†—Ñü@\Îl3õAà\n∑ΩI\Ïm\„c≠æ;\’)N±≠fu\ÌßvVC\Œ⁄ì\Êi›ûC\‹h\—ıDmÄèK\’AóΩÄøÚw±\ﬂ¶ôylkÃ∫Éë®ı\0™Æ\…>≥˜\€4\’¯è~iÿ∑{–ïGCe\ÿ,Eπ2\Ï6¶{4\Ô`\ÔãL-Ùπ9\›tÉ\ﬁ,îûª:]Ã¥\Èuööê\√ı\ËÙªùcsQˇ=¿s\÷v≤Ö\¬\rdÒ\"êÔµµï\”˛\«~\Ï\ÀC{\0rN\Á¡\œU∂Y\Î|\ÓO\⁄\Zäz\Ó\—\0iÈà≠©ˆ8\"0#,\"ÄúÖ)âæ\Ëa\ÁF9\«p=•µ\"\ÍxLk/P\‹\œi\Ìm&Øvˇ±˜<at\ﬂO[;€ó[C\ƒ\'¸;›ïs®}1\∆N\€c\Œˆ˛\ÁÅ\”KØh@\"Úû\È1C^\ﬂG\œ!7ó˝í\\ó¶_öabL\0’≤Ûπˆ\‹˚jkBG†\n\'\Ï~ÙÆ\Õ˚ïM∂ß∞\”.ZGÛ∞“Øv=\«\€6`4ç\ﬁ\⁄v\Î\ÔÅ¬±d,Øù3µ\€\Œ\nuÖFÆ1\Ád˚\Ì\—\ﬁe±\‘±&P@\ÂöQKqµÇh˛‰±ôz\›v0[\‚=\›˚a#\Ã˘j∑wvïCú¸b≤Ú\Œr˚ºıØ¸í\\=Ø\›|π\‹\≈E¥ç£´ï\È\n_z≤K2OLI\…˛I!\À \√\‘k\÷W_0Õµ\»H§F´∏\ \"\∆\«-âÖNHπñÁíøM9\Â\r›ñ:R ›µØı\r]tuH\”\¬\ƒ\r¡Y_èãŒ∑u©w!2Æ:∏ÙN∂<A\Ó\Î(	?j`‹ß\◊`∫˜à\«n\‰@Ñ<óòwjõ˘ ¥Ç\r˜\’Å†/\"DU\Ã0\n.u\œ˛∫.£zÑh¢ïXC\”Úπ\ÿ\…\Z>\\\€\‡,\ÿC\œÆﬁä\⁄I•\Óõ;<-ëàxà\›QVQ7\‹*ß\–¶ºK¡ë§\Zπˆì=\ﬁÚ∑á5å\Í/£å<˙Ú\‚(èEG{Lq\¬1\◊y\ÏÙ£&\Ê\‚GOJGÒÙ\‰\‰p∞`z\‡\—\∆f\\8\‡Ø.N∫T\Ì>/v«É\Â»ô\∆\ﬂ~Q	µ8…∞Òw^v∞¸ì?wrb£ºSØÕ´æ∫f†	4∏D´OÇä\Ê¯tâü´\rÇÑAB| +j›∑\Ô¯Ää´à£ºåè≤k\ﬂ~sP\≈\√|Ä⁄∏∞¿ü\‘g\È\–Ç’Æ x\‹\÷}†\nı\È7ø.\„Ñ<2.8å1s\'\÷/`ß\∆\‡R\√cA:Ny\·∫jÑ∞ê\\\›\∆R1,Ú.-PíuöÖ\Êr*á˘i\÷U=x∫\ÔqWÇ£y}˜\◊|r\“?˜\'@–áXI~`∫Oá\“\Àh\⁄Àï[YD\‹r\·yyÇ</;ƒÖ“≥\…SØ}t¢ÖjJ\ËMº˘bwú\nµè\„ˆ\›	~w\∆yU\ @h?∑g⁄ß~X\"p`òX.\Ï{ê†8(Ia˝PKxë\ÿD\'\ÿ\rO+B\Ã\Ô\ÈÆ(±~0g<ôr(®ôX\∆x¢\Ê ∂\∆-j&±\‡ò¸\÷vb+˜k€Ω\⁄qÙ\·¶\“Dπ\0\n<%˛Û˜∞å`q\"ÙX\ÿ\ÔÚ¡Éàp\·l¡qê0ò“à\√{¥\„êcJL%îX<=5Ò{ê˙àÑöâ˘\‹˜\√z#øäPç\'˜ı¿MætØ\‘ä˛¿Ω<±#ü⁄±Ωñ©¸Æ:_/>\⁄Q\ﬂ◊∑\ﬂYÖƒüz?t\Ô°\Ï\”\\\Ã;\‡\Ë8/\‰\›Ò∂\Á\À¯\0\–ë\Œ.ï&´æ\…GR/Jè±ü\Œ{Ú≠¯æq\Î∏&øE¨ †y¨∫…Ø¯Hˆ.ºòe˝∫Ò\Î˘˙ÆP\Ì\r‹Ω\Êöw\œ\Õ*†+n\‡¶T\◊|á*©xõ)s^ö\nu.\r™°äÇ`Y\rwÒ¨T√•A’¨z£l\€ZD/?¥B1õÆnñ3_fm^sC∫U]©ªKÅ™£≠\"b§_o¥T\Íıwêvôd¶\‹å)§\€à6|§–ñúfî*§t®¶\÷W$_V°†\Ã˝\Œkï\ZÖT®>\Óò\”bT⁄•Ló6ô:\—Lø≥\ÊT\Ëw)˝\∆˛—âWµÈóé_uœñ˜©\Õ\ƒm≠îT\◊$ÄÆJ≥ò-∑pgn\—<Y5öømâ∑âXÀª&É°\"˛hI©àOÑ*™\ﬁUÀóñ\”_=∞P*T≥@\’fmÆ|i-’∏›µR+óU\◊m%-fQ´r©≥®MgQùh¶\ﬂ≈öR+Ëì†\Z\‚Ùa\Ÿ∏≥X¥\Â\0HÚ≠\‰BÚUìsµY\Ì§.î\‰\ZŸÑFVEVΩTá2äRN£î25&Àå\ÀÃ´hÜ\Ë-\–f£\Îy˜EQì5Å=∏\“Jö‘øÖ\ÿAã\Œ\„ÅGÄ˛[F)	\’Åé¢\‹V∏ØÉYa}\√%XÜ\–EÖÆ:sÅõ\Z\„c\0d\ƒÉ\ŸÑZ\0Xb\n\»\0¢q≠ã*{≥œß≥|4®õh¥°°¢^µÚªhU.∂x¶¿q\◊=ª%\È\ÊX\Ô¥\ﬁ\Ê∏g=\◊l)e?]V]\¬5∞\≈\«}\Z\ÎuèN\"é\œ@Gm\\§ÖÜ\Às\’x\·˚^\Á*\‰\ﬂÙ\‹\Ë¥€í*Uï˝Ç\≈Tt5\‚\¬\n!\€\∆\€> Á°äû\Ï\‚.åjÒ\–ÿó\Ÿ0\02EÛªΩ1\0rE4Lw\‰˛ ¿\»{Lña]Vú\ÌÙ]\◊˚\Êù˜»πãL£NäÇˆxE\ÿ);\„˜,òè\‘\‘ê¸•ÄÆ\Í<™Çi\‡∑Ú¿ﬁÜM¡+\Îhù\¬cvOÚ7A:©ÛJ	≤ÅPè˚∫é˛ü\„\r\ÓÆfLu~¡Gv\Ïn\Î|4ä∑—µ »∏\„GN<â∞BKgo\À£\ 2˚dåfó≠±	±\œuO5]4ô>ÅΩz\ÈP\Â?\ÌnMR\ﬂY\»u\‡{än¢¶©@w\Ì\ÃXÉå0v\◊SPÉ\Õ]\Ó*üæ®˝\"l£…µ¸FcU8\’<V,°≥≠ı°∏πØ¨\Í\Õ%j87y\'Ò≠§÷æ.\»6“Å5∫\ÿ\\\‡-≠^\ÍÑ\ÈZ˚\Œ@g˚‘•ù-\ÍK±\Ê˚\…4IÚ@\Ÿ*H\„º˙z∂∏\ﬁ%\ÂãpıØ74èzgåfBWÇ≠Uó\Á}rü∂Ü_Rã\⁄,\“Cóî\…RêÛ¨à\Ó…™`\…+ö\ÁQÚ0ü›íxW°‰éÆ\ﬂ\'üv\≈vW∞.\”\Õ]¸çgFi:¶´ˇl°¥˘\Ï”∂¸ïá\Ëkfπ§üí_vQº\Ó\⁄˝xˇ!Q⁄§5OïcYîO=|\Î(}LKB\r˚:S∫ˆ`=ˇî‹ê\'\Í”∂/9˝@\»\Í˚˛≠iÜ1Ñ\»ˆ≥7y\»\»&ohÙ\Â\ŸOÜ\·ı\Ê\Î\ﬂ˛v§.j≥ó\0','6.2.0-61023');
/*!40000 ALTER TABLE `__migrationhistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `acrescimos_limite`
--

DROP TABLE IF EXISTS `acrescimos_limite`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `acrescimos_limite` (
  `codigo_grupo` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `efetivo` tinyint(1) NOT NULL,
  `qtda_limite` int(11) NOT NULL,
  `intervalo_acrescimo` int(11) NOT NULL,
  `qtda_acrescimo` int(11) NOT NULL,
  PRIMARY KEY (`codigo_grupo`,`efetivo`),
  KEY `IX_codigo_grupo` (`codigo_grupo`),
  CONSTRAINT `FK_acrescimos_limite_grupos_codigo_grupo` FOREIGN KEY (`codigo_grupo`) REFERENCES `grupos` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `acrescimos_limite`
--

LOCK TABLES `acrescimos_limite` WRITE;
/*!40000 ALTER TABLE `acrescimos_limite` DISABLE KEYS */;
INSERT INTO `acrescimos_limite` VALUES ('C-1',0,10000,2500,2),('C-1',1,10000,2500,2),('C-10',0,10000,2500,2),('C-10',1,10000,2500,2),('C-11',0,10000,2500,2),('C-11',1,10000,2500,2),('C-12',0,10000,2500,2),('C-12',1,10000,2500,2),('C-13',0,10000,2500,2),('C-13',1,10000,2500,2),('C-14',0,10000,2500,2),('C-14',1,10000,2500,2),('C-14a',0,10000,2500,1),('C-14a',1,10000,2500,1),('C-15',0,10000,2500,2),('C-15',1,10000,2500,2),('C-16',0,10000,2500,2),('C-16',1,10000,2500,2),('C-17',0,10000,2500,2),('C-17',1,10000,2500,2),('C-18',0,10000,2500,2),('C-18',1,10000,2500,2),('C-18a',0,10000,2500,2),('C-18a',1,10000,2500,2),('C-19',0,10000,2500,1),('C-19',1,10000,2500,1),('C-1a',0,10000,2500,2),('C-1a',1,10000,2500,2),('C-2',0,10000,2500,1),('C-2',1,10000,2500,2),('C-20',0,10000,2500,1),('C-20',1,10000,2500,2),('C-21',0,10000,2500,1),('C-21',1,10000,2500,1),('C-22',0,10000,2500,2),('C-22',1,10000,2500,2),('C-23',0,10000,2500,1),('C-23',1,10000,2500,1),('C-24',0,10000,2500,2),('C-24',1,10000,2500,2),('C-24a',0,10000,2500,1),('C-24a',1,10000,2500,1),('C-24b',0,10000,2500,2),('C-24b',1,10000,2500,2),('C-25',0,10000,2500,1),('C-25',1,10000,2500,1),('C-26',0,10000,2500,1),('C-26',1,10000,2500,1),('C-27',0,10000,2500,1),('C-27',1,10000,2500,1),('C-28',0,10000,2500,1),('C-28',1,10000,2500,1),('C-29',0,10000,2500,1),('C-29',1,10000,2500,1),('C-3',0,10000,2500,2),('C-3',1,10000,2500,2),('C-30',0,10000,2500,1),('C-30',1,10000,2500,2),('C-31',0,10000,2500,1),('C-31',1,10000,2500,1),('C-32',0,10000,2500,1),('C-32',1,10000,2500,1),('C-33',0,10000,2500,1),('C-33',1,10000,2500,1),('C-34',0,10000,2500,2),('C-34',1,10000,2500,2),('C-35',0,10000,2500,1),('C-35',1,10000,2500,1),('C-3a',0,10000,2500,1),('C-3a',1,10000,2500,1),('C-4',0,10000,2500,1),('C-4',1,10000,2500,1),('C-5',0,10000,2500,2),('C-5',1,10000,2500,2),('C-5a',0,10000,2500,1),('C-5a',1,10000,2500,1),('C-6',0,10000,2500,2),('C-6',1,10000,2500,2),('C-7',0,10000,2500,1),('C-7',1,10000,2500,1),('C-7a',0,10000,2500,2),('C-7a',1,10000,2500,2),('C-8',0,10000,2500,1),('C-8',1,10000,2500,1),('C-9',0,10000,2500,1),('C-9',1,10000,2500,1);
/*!40000 ALTER TABLE `acrescimos_limite` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidatos`
--

DROP TABLE IF EXISTS `candidatos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `candidatos` (
  `funcionario_id` int(11) NOT NULL,
  `codigo_eleicao` int(11) NOT NULL,
  `horario_candidatura` datetime NOT NULL,
  `validado` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`funcionario_id`,`codigo_eleicao`),
  KEY `IX_funcionario_id` (`funcionario_id`),
  KEY `IX_codigo_eleicao` (`codigo_eleicao`),
  CONSTRAINT `FK_candidatos_eleicoes_codigo_eleicao` FOREIGN KEY (`codigo_eleicao`) REFERENCES `eleicoes` (`codigo`),
  CONSTRAINT `FK_candidatos_funcionarios_funcionario_id` FOREIGN KEY (`funcionario_id`) REFERENCES `funcionarios` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidatos`
--

LOCK TABLES `candidatos` WRITE;
/*!40000 ALTER TABLE `candidatos` DISABLE KEYS */;
/*!40000 ALTER TABLE `candidatos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `candidaturas_reprovadas`
--

DROP TABLE IF EXISTS `candidaturas_reprovadas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `candidaturas_reprovadas` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `funcionario_id` int(11) NOT NULL,
  `codigo_eleicao` int(11) NOT NULL,
  `motivo` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `IX_funcionario_id_codigo_eleicao` (`funcionario_id`,`codigo_eleicao`),
  CONSTRAINT `FK_d00f4b14d09d4725b88c1760621f80c4` FOREIGN KEY (`funcionario_id`, `codigo_eleicao`) REFERENCES `candidatos` (`funcionario_id`, `codigo_eleicao`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `candidaturas_reprovadas`
--

LOCK TABLES `candidaturas_reprovadas` WRITE;
/*!40000 ALTER TABLE `candidaturas_reprovadas` DISABLE KEYS */;
/*!40000 ALTER TABLE `candidaturas_reprovadas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eleicoes`
--

DROP TABLE IF EXISTS `eleicoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `eleicoes` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `gestao` varchar(15) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `data_inicio` datetime NOT NULL,
  `data_fechamento` datetime DEFAULT NULL,
  `codigo_etapa` int(11) DEFAULT NULL,
  `codigo_unidade` int(11) NOT NULL,
  `codigo_sindicato` int(11) DEFAULT NULL,
  `codigo_modulo` int(11) NOT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `gestao_unq` (`gestao`,`codigo_unidade`,`codigo_modulo`),
  KEY `IX_codigo_etapa` (`codigo_etapa`),
  KEY `IX_codigo_sindicato` (`codigo_sindicato`),
  KEY `FK_eleicoes_modulo_codigo_modulo` (`codigo_modulo`),
  KEY `FK_eleicoes_unidades_codigo_unidade` (`codigo_unidade`),
  CONSTRAINT `FK_eleicoes_etapas_codigo_etapa` FOREIGN KEY (`codigo_etapa`) REFERENCES `etapas` (`codigo`),
  CONSTRAINT `FK_eleicoes_modulo_codigo_modulo` FOREIGN KEY (`codigo_modulo`) REFERENCES `modulo` (`codigo`),
  CONSTRAINT `FK_eleicoes_sindicatos_codigo_sindicato` FOREIGN KEY (`codigo_sindicato`) REFERENCES `sindicatos` (`codigo`),
  CONSTRAINT `FK_eleicoes_unidades_codigo_unidade` FOREIGN KEY (`codigo_unidade`) REFERENCES `unidades` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eleicoes`
--

LOCK TABLES `eleicoes` WRITE;
/*!40000 ALTER TABLE `eleicoes` DISABLE KEYS */;
/*!40000 ALTER TABLE `eleicoes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empresas`
--

DROP TABLE IF EXISTS `empresas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `empresas` (
  `codigo` int(11) NOT NULL,
  `RazaoSocial` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empresas`
--

LOCK TABLES `empresas` WRITE;
/*!40000 ALTER TABLE `empresas` DISABLE KEYS */;
INSERT INTO `empresas` VALUES (9,'ALGAR SEGURANCA ELETRONICA E SERVICOS LTDA'),(10,'ALGAR SEGURANCA E VIGILANCIA LTDA'),(15,'ALGAR S/A EMPREENDIMENTOS E PARTICIPACOES'),(18,'ABC AGRICULTURA E PECUARIA SA- ABC A&P'),(20,'ABC AGROPEC BRASIL NORTE S/A PROD EXPORT'),(25,'ALGAR TELECOM S/A'),(27,'ALGAR MULTIMIDIA S/A'),(28,'ENGESET ENG SERV TELECOMUNICACOES SA'),(29,'ALGAR TECNOLOGIA E CONSULTORIA S/A'),(33,'ALGAR TI CONSULTORIA S/A'),(38,'ALGAR SOLUCOES EM TIC S/A'),(39,'ALSOL ENERGIAS RENOVAVEIS S/A');
/*!40000 ALTER TABLE `empresas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `etapas`
--

DROP TABLE IF EXISTS `etapas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `etapas` (
  `codigo` int(11) NOT NULL,
  `etapa` varchar(180) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `dias_prazo` int(11) DEFAULT NULL,
  `codigo_modulo` int(11) NOT NULL,
  `codigo_template` int(11) DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `nome_etapa_unq` (`etapa`,`codigo_modulo`),
  KEY `IX_codigo_template` (`codigo_template`),
  KEY `FK_etapas_modulo_codigo_modulo` (`codigo_modulo`),
  CONSTRAINT `FK_etapas_modulo_codigo_modulo` FOREIGN KEY (`codigo_modulo`) REFERENCES `modulo` (`codigo`),
  CONSTRAINT `FK_etapas_templates_emails_codigo_template` FOREIGN KEY (`codigo_template`) REFERENCES `templates_emails` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `etapas`
--

LOCK TABLES `etapas` WRITE;
/*!40000 ALTER TABLE `etapas` DISABLE KEYS */;
INSERT INTO `etapas` VALUES (1,'EDITAL DE CONVOCA√á√ÉO PARA ELEI√á√ÉO',2,1,NULL),(2,'FORMA√á√ÉO DA COMISS√ÉO ELEITORAL',3,1,NULL),(3,'ENVIAR C√ìPIA DO EDITAL DE CONVOCA√á√ÉO AO SINDICATO',4,1,NULL),(4,'IN√çCIO INSCRI√á√ïES CANDIDATOS',14,1,NULL),(5,'T√âRMINO INSCRI√á√ïES CANDIDATOS',3,1,NULL),(6,'PUBLICA√á√ÉO EDITAL DE INSCRI√á√ÉO DE CANDIDATOS',1,1,NULL),(9,'REALIZA√á√ÉO DA ELEI√á√ÉO (VOTA√á√ÉO)',20,1,NULL),(10,'REALIZA√á√ÉO DA APURA√á√ÉO',3,1,NULL),(11,'RESULTADO DA ELEI√á√ÉO - ATA DA ELEI√á√ÉO',1,1,NULL),(12,'CURSO PARA CIPEIROS (DATA M√çNIMA)',20,1,NULL),(13,'CURSO PARA CIPEIROS (DATA M√ÅXIMA)',4,1,NULL),(14,'T√âRMINO DO MANDATO ANTERIOR',2,1,NULL),(15,'REALIZA√á√ÉO DA POSSE - ATA DE POSSE NOVOS MEMBROS',1,1,NULL),(16,'ORGANIZA√á√ÉO DO CALEND√ÅRIO REUNI√ïES MENSAIS',1,1,NULL),(17,'EDITAL DE CONVOCA√á√ÉO PARA ELEI√á√ÉO',2,2,NULL),(18,'FORMA√á√ÉO DA COMISS√ÉO ELEITORAL',3,2,NULL),(19,'IN√çCIO INSCRI√á√ïES CANDIDATOS',14,2,NULL),(20,'T√âRMINO INSCRI√á√ïES CANDIDATOS',3,2,NULL),(21,'PUBLICA√á√ÉO EDITAL DE INSCRI√á√ÉO DE CANDIDATOS',1,2,NULL),(24,'REALIZA√á√ÉO DA ELEI√á√ÉO (VOTA√á√ÉO)',20,2,NULL),(25,'REALIZA√á√ÉO DA APURA√á√ÉO',3,2,NULL),(26,'RESULTADO DA ELEI√á√ÉO - ATA DA ELEI√á√ÉO',1,2,NULL),(28,'REALIZA√á√ÉO DA POSSE - ATA DE POSSE NOVOS MEMBROS',1,2,NULL),(29,'ORGANIZA√á√ÉO DO CALEND√ÅRIO REUNI√ïES MENSAIS',1,2,NULL),(30,'T√âRMINO DO MANDATO ANTERIOR',2,2,NULL);
/*!40000 ALTER TABLE `etapas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `funcionarios`
--

DROP TABLE IF EXISTS `funcionarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `funcionarios` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `matricula` varchar(15) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `codigo_empresa` int(11) NOT NULL,
  `nome` varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `login` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `cargo` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `area` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `data_admissao` datetime DEFAULT NULL,
  `data_nascimento` datetime DEFAULT NULL,
  `email` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `codigo_gestor` int(11) DEFAULT NULL,
  `sobre` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `thumbnail` longblob,
  PRIMARY KEY (`id`),
  UNIQUE KEY `IdxFuncionario` (`matricula`,`codigo_empresa`),
  UNIQUE KEY `IX_login` (`login`),
  KEY `IX_codigo_gestor` (`codigo_gestor`),
  KEY `FK_funcionarios_empresas_codigo_empresa` (`codigo_empresa`),
  CONSTRAINT `FK_funcionarios_empresas_codigo_empresa` FOREIGN KEY (`codigo_empresa`) REFERENCES `empresas` (`codigo`),
  CONSTRAINT `FK_funcionarios_gestores_codigo_gestor` FOREIGN KEY (`codigo_gestor`) REFERENCES `gestores` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funcionarios`
--

LOCK TABLES `funcionarios` WRITE;
/*!40000 ALTER TABLE `funcionarios` DISABLE KEYS */;
/*!40000 ALTER TABLE `funcionarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `funcionarios_eleicoes`
--

DROP TABLE IF EXISTS `funcionarios_eleicoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `funcionarios_eleicoes` (
  `codigo_eleicao` int(11) NOT NULL,
  `funcionario_id` int(11) NOT NULL,
  PRIMARY KEY (`codigo_eleicao`,`funcionario_id`),
  KEY `IX_codigo_eleicao` (`codigo_eleicao`),
  KEY `IX_funcionario_id` (`funcionario_id`),
  CONSTRAINT `FK_funcionarios_eleicoes_eleicoes_codigo_eleicao` FOREIGN KEY (`codigo_eleicao`) REFERENCES `eleicoes` (`codigo`),
  CONSTRAINT `FK_funcionarios_eleicoes_funcionarios_funcionario_id` FOREIGN KEY (`funcionario_id`) REFERENCES `funcionarios` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funcionarios_eleicoes`
--

LOCK TABLES `funcionarios_eleicoes` WRITE;
/*!40000 ALTER TABLE `funcionarios_eleicoes` DISABLE KEYS */;
/*!40000 ALTER TABLE `funcionarios_eleicoes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `funcionarios_fotos`
--

DROP TABLE IF EXISTS `funcionarios_fotos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `funcionarios_fotos` (
  `funcionario_id` int(11) NOT NULL,
  `foto` longblob NOT NULL,
  PRIMARY KEY (`funcionario_id`),
  KEY `IX_funcionario_id` (`funcionario_id`),
  CONSTRAINT `FK_funcionarios_fotos_funcionarios_funcionario_id` FOREIGN KEY (`funcionario_id`) REFERENCES `funcionarios` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `funcionarios_fotos`
--

LOCK TABLES `funcionarios_fotos` WRITE;
/*!40000 ALTER TABLE `funcionarios_fotos` DISABLE KEYS */;
/*!40000 ALTER TABLE `funcionarios_fotos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `gestores`
--

DROP TABLE IF EXISTS `gestores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `gestores` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `email` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`codigo`),
  UNIQUE KEY `IX_nome` (`nome`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `gestores`
--

LOCK TABLES `gestores` WRITE;
/*!40000 ALTER TABLE `gestores` DISABLE KEYS */;
/*!40000 ALTER TABLE `gestores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupos`
--

DROP TABLE IF EXISTS `grupos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `grupos` (
  `codigo` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupos`
--

LOCK TABLES `grupos` WRITE;
/*!40000 ALTER TABLE `grupos` DISABLE KEYS */;
INSERT INTO `grupos` VALUES ('C-1'),('C-10'),('C-11'),('C-12'),('C-13'),('C-14'),('C-14a'),('C-15'),('C-16'),('C-17'),('C-18'),('C-18a'),('C-19'),('C-1a'),('C-2'),('C-20'),('C-21'),('C-22'),('C-23'),('C-24'),('C-24a'),('C-24b'),('C-25'),('C-26'),('C-27'),('C-28'),('C-29'),('C-3'),('C-30'),('C-31'),('C-32'),('C-33'),('C-34'),('C-35'),('C-3a'),('C-4'),('C-5'),('C-5a'),('C-6'),('C-7'),('C-7a'),('C-8'),('C-9');
/*!40000 ALTER TABLE `grupos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `log_email`
--

DROP TABLE IF EXISTS `log_email`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `log_email` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `para` longtext NOT NULL,
  `assunto` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `erro` longtext,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `log_email`
--

LOCK TABLES `log_email` WRITE;
/*!40000 ALTER TABLE `log_email` DISABLE KEYS */;
/*!40000 ALTER TABLE `log_email` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modulo`
--

DROP TABLE IF EXISTS `modulo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `modulo` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome_modulo` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modulo`
--

LOCK TABLES `modulo` WRITE;
/*!40000 ALTER TABLE `modulo` DISABLE KEYS */;
INSERT INTO `modulo` VALUES (1,'CIPA'),(2,'Comiss√£o Interna de Trabalhadores');
/*!40000 ALTER TABLE `modulo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prazos_etapas`
--

DROP TABLE IF EXISTS `prazos_etapas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `prazos_etapas` (
  `codigo_eleicao` int(11) NOT NULL,
  `codigo_etapa` int(11) NOT NULL,
  `data_realizada` datetime DEFAULT NULL,
  `data_proposta` datetime DEFAULT NULL,
  PRIMARY KEY (`codigo_eleicao`,`codigo_etapa`),
  KEY `IX_codigo_eleicao` (`codigo_eleicao`),
  KEY `IX_codigo_etapa` (`codigo_etapa`),
  CONSTRAINT `FK_prazos_etapas_eleicoes_codigo_eleicao` FOREIGN KEY (`codigo_eleicao`) REFERENCES `eleicoes` (`codigo`),
  CONSTRAINT `FK_prazos_etapas_etapas_codigo_etapa` FOREIGN KEY (`codigo_etapa`) REFERENCES `etapas` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prazos_etapas`
--

LOCK TABLES `prazos_etapas` WRITE;
/*!40000 ALTER TABLE `prazos_etapas` DISABLE KEYS */;
/*!40000 ALTER TABLE `prazos_etapas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `qtda_comissao_interna`
--

DROP TABLE IF EXISTS `qtda_comissao_interna`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `qtda_comissao_interna` (
  `qtda_min` int(11) NOT NULL,
  `valor` int(11) NOT NULL,
  PRIMARY KEY (`qtda_min`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `qtda_comissao_interna`
--

LOCK TABLES `qtda_comissao_interna` WRITE;
/*!40000 ALTER TABLE `qtda_comissao_interna` DISABLE KEYS */;
INSERT INTO `qtda_comissao_interna` VALUES (0,0),(200,3),(3001,5),(5001,7);
/*!40000 ALTER TABLE `qtda_comissao_interna` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `qtda_grupos`
--

DROP TABLE IF EXISTS `qtda_grupos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `qtda_grupos` (
  `codigo_grupo` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `efetivo` tinyint(1) NOT NULL,
  `qtda_min` int(11) NOT NULL,
  `qtda_max` int(11) DEFAULT NULL,
  `valor` int(11) NOT NULL,
  PRIMARY KEY (`codigo_grupo`,`efetivo`,`qtda_min`),
  KEY `IX_codigo_grupo_efetivo` (`codigo_grupo`,`efetivo`),
  CONSTRAINT `FK_qtda_grupos_acrescimos_limite_codigo_grupo_efetivo` FOREIGN KEY (`codigo_grupo`, `efetivo`) REFERENCES `acrescimos_limite` (`codigo_grupo`, `efetivo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `qtda_grupos`
--

LOCK TABLES `qtda_grupos` WRITE;
/*!40000 ALTER TABLE `qtda_grupos` DISABLE KEYS */;
INSERT INTO `qtda_grupos` VALUES ('C-1',0,0,19,0),('C-1',0,20,50,1),('C-1',0,51,500,3),('C-1',0,501,1000,4),('C-1',0,1001,2500,7),('C-1',0,2501,5000,9),('C-1',0,5001,10000,12),('C-1',1,0,19,0),('C-1',1,20,50,1),('C-1',1,51,100,3),('C-1',1,101,500,4),('C-1',1,501,1000,6),('C-1',1,1001,2500,9),('C-1',1,2501,5000,12),('C-1',1,5001,10000,15),('C-10',0,0,19,0),('C-10',0,20,50,1),('C-10',0,51,100,2),('C-10',0,101,300,3),('C-10',0,301,1000,4),('C-10',0,1001,2500,6),('C-10',0,2501,5000,7),('C-10',0,5001,10000,8),('C-10',1,0,19,0),('C-10',1,20,50,1),('C-10',1,51,100,2),('C-10',1,101,140,3),('C-10',1,141,500,4),('C-10',1,501,1000,5),('C-10',1,1001,2500,8),('C-10',1,2501,5000,9),('C-10',1,5001,10000,10),('C-11',0,0,19,0),('C-11',0,20,50,1),('C-11',0,51,80,2),('C-11',0,81,300,3),('C-11',0,301,1000,4),('C-11',0,1001,2500,7),('C-11',0,2501,5000,8),('C-11',0,5001,10000,10),('C-11',1,0,19,0),('C-11',1,20,50,1),('C-11',1,51,80,2),('C-11',1,81,120,3),('C-11',1,121,300,4),('C-11',1,301,500,5),('C-11',1,501,1000,6),('C-11',1,1001,2500,9),('C-11',1,2501,5000,10),('C-11',1,5001,10000,12),('C-12',0,0,19,0),('C-12',0,20,50,1),('C-12',0,51,80,2),('C-12',0,81,300,3),('C-12',0,301,500,4),('C-12',0,501,2500,6),('C-12',0,2501,5000,7),('C-12',0,5001,10000,8),('C-12',1,0,19,0),('C-12',1,20,50,1),('C-12',1,51,80,2),('C-12',1,81,120,3),('C-12',1,121,300,4),('C-12',1,301,500,5),('C-12',1,501,1000,7),('C-12',1,1001,2500,8),('C-12',1,2501,5000,9),('C-12',1,5001,10000,10),('C-13',0,0,19,0),('C-13',0,20,50,1),('C-13',0,51,300,3),('C-13',0,301,500,4),('C-13',0,501,1000,5),('C-13',0,1001,2500,7),('C-13',0,2501,5000,8),('C-13',0,5001,10000,10),('C-13',1,0,19,0),('C-13',1,20,50,1),('C-13',1,51,140,3),('C-13',1,141,300,4),('C-13',1,301,500,5),('C-13',1,501,1000,6),('C-13',1,1001,2500,9),('C-13',1,2501,5000,11),('C-13',1,5001,10000,13),('C-14',0,0,19,0),('C-14',0,20,50,1),('C-14',0,51,100,2),('C-14',0,101,140,3),('C-14',0,141,500,4),('C-14',0,501,1000,5),('C-14',0,1001,2500,7),('C-14',0,2501,10000,9),('C-14',1,0,19,0),('C-14',1,20,50,1),('C-14',1,51,100,2),('C-14',1,101,120,3),('C-14',1,121,300,4),('C-14',1,301,500,5),('C-14',1,501,1000,6),('C-14',1,1001,2500,9),('C-14',1,2501,10000,11),('C-14a',0,0,50,0),('C-14a',0,51,100,1),('C-14a',0,101,300,2),('C-14a',0,301,2500,3),('C-14a',0,2501,10000,4),('C-14a',1,0,50,0),('C-14a',1,51,100,1),('C-14a',1,101,300,2),('C-14a',1,301,1000,3),('C-14a',1,1001,2500,4),('C-14a',1,2501,5000,5),('C-14a',1,5001,10000,6),('C-15',0,0,19,0),('C-15',0,20,50,1),('C-15',0,51,300,3),('C-15',0,301,1000,4),('C-15',0,1001,2500,6),('C-15',0,2501,5000,8),('C-15',0,5001,10000,10),('C-15',1,0,19,0),('C-15',1,20,50,1),('C-15',1,51,100,3),('C-15',1,101,300,4),('C-15',1,301,500,5),('C-15',1,501,1000,6),('C-15',1,1001,2500,8),('C-15',1,2501,5000,10),('C-15',1,5001,10000,12),('C-16',0,0,19,0),('C-16',0,20,50,1),('C-16',0,51,80,2),('C-16',0,81,300,3),('C-16',0,301,1000,4),('C-16',0,1001,2500,6),('C-16',0,2501,5000,7),('C-16',0,5001,10000,9),('C-16',1,0,19,0),('C-16',1,20,50,1),('C-16',1,51,80,2),('C-16',1,81,140,3),('C-16',1,141,300,4),('C-16',1,301,500,5),('C-16',1,501,1000,6),('C-16',1,1001,2500,8),('C-16',1,2501,5000,10),('C-16',1,5001,10000,12),('C-17',0,0,19,0),('C-17',0,20,50,1),('C-17',0,51,100,2),('C-17',0,101,300,3),('C-17',0,301,500,4),('C-17',0,501,1000,5),('C-17',0,1001,2500,7),('C-17',0,2501,5000,8),('C-17',0,5001,10000,10),('C-17',1,0,19,0),('C-17',1,20,50,1),('C-17',1,51,100,2),('C-17',1,101,500,4),('C-17',1,501,1000,6),('C-17',1,1001,2500,8),('C-17',1,2501,5000,10),('C-17',1,5001,10000,12),('C-18',0,0,50,0),('C-18',0,51,100,2),('C-18',0,101,300,3),('C-18',0,301,500,4),('C-18',0,501,1000,5),('C-18',0,1001,2500,7),('C-18',0,2501,5000,8),('C-18',0,5001,10000,10),('C-18',1,0,50,0),('C-18',1,51,100,2),('C-18',1,101,500,4),('C-18',1,501,1000,6),('C-18',1,1001,2500,8),('C-18',1,2501,5000,10),('C-18',1,5001,10000,12),('C-18a',0,0,50,0),('C-18a',0,51,300,3),('C-18a',0,301,500,4),('C-18a',0,501,1000,5),('C-18a',0,1001,2500,7),('C-18a',0,2501,5000,9),('C-18a',0,5001,10000,12),('C-18a',1,0,50,0),('C-18a',1,51,100,3),('C-18a',1,101,500,4),('C-18a',1,501,1000,6),('C-18a',1,1001,2500,9),('C-18a',1,2501,5000,12),('C-18a',1,5001,10000,15),('C-19',0,0,50,0),('C-19',0,51,100,1),('C-19',0,101,300,2),('C-19',0,301,2500,3),('C-19',0,2501,10000,4),('C-19',1,0,50,0),('C-19',1,51,100,1),('C-19',1,101,300,2),('C-19',1,301,1000,3),('C-19',1,1001,2500,4),('C-19',1,2501,5000,5),('C-19',1,5001,10000,6),('C-1a',0,0,19,0),('C-1a',0,20,50,1),('C-1a',0,51,300,3),('C-1a',0,301,500,4),('C-1a',0,501,1000,5),('C-1a',0,1001,2500,8),('C-1a',0,2501,5000,9),('C-1a',0,5001,10000,12),('C-1a',1,0,19,0),('C-1a',1,20,50,1),('C-1a',1,51,100,3),('C-1a',1,101,500,4),('C-1a',1,501,1000,6),('C-1a',1,1001,2500,9),('C-1a',1,2501,5000,12),('C-1a',1,5001,10000,15),('C-2',0,0,19,0),('C-2',0,20,50,1),('C-2',0,51,100,2),('C-2',0,101,140,3),('C-2',0,141,500,4),('C-2',0,501,1000,5),('C-2',0,1001,2500,6),('C-2',0,2501,5000,7),('C-2',0,5001,10000,9),('C-2',1,0,19,0),('C-2',1,20,50,1),('C-2',1,51,100,2),('C-2',1,101,120,3),('C-2',1,121,300,4),('C-2',1,301,500,5),('C-2',1,501,1000,6),('C-2',1,1001,2500,7),('C-2',1,2501,5000,10),('C-2',1,5001,10000,11),('C-20',0,0,29,0),('C-20',0,30,80,1),('C-20',0,81,500,3),('C-20',0,501,2500,4),('C-20',0,2501,5000,5),('C-20',0,5001,10000,6),('C-20',1,0,29,0),('C-20',1,30,80,1),('C-20',1,81,300,3),('C-20',1,301,500,4),('C-20',1,501,2500,5),('C-20',1,2501,5000,6),('C-20',1,5001,10000,8),('C-21',0,0,50,0),('C-21',0,51,100,1),('C-21',0,101,300,2),('C-21',0,301,2500,3),('C-21',0,2501,5000,4),('C-21',0,5001,10000,5),('C-21',1,0,50,0),('C-21',1,51,100,1),('C-21',1,101,300,2),('C-21',1,301,1000,3),('C-21',1,1001,2500,4),('C-21',1,2501,5000,5),('C-21',1,5001,10000,6),('C-22',0,0,19,0),('C-22',0,20,50,1),('C-22',0,51,100,2),('C-22',0,101,500,3),('C-22',0,501,1000,5),('C-22',0,1001,2500,6),('C-22',0,2501,5000,8),('C-22',0,5001,10000,9),('C-22',1,0,19,0),('C-22',1,20,50,1),('C-22',1,51,100,2),('C-22',1,101,140,3),('C-22',1,141,500,4),('C-22',1,501,1000,6),('C-22',1,1001,2500,8),('C-22',1,2501,5000,10),('C-22',1,5001,10000,12),('C-23',0,0,50,0),('C-23',0,51,100,1),('C-23',0,101,500,2),('C-23',0,501,2500,3),('C-23',0,2501,5000,4),('C-23',0,5001,10000,5),('C-23',1,0,50,0),('C-23',1,51,100,1),('C-23',1,101,500,2),('C-23',1,501,1000,3),('C-23',1,1001,2500,4),('C-23',1,2501,5000,5),('C-23',1,5001,10000,6),('C-24',0,0,19,0),('C-24',0,20,50,1),('C-24',0,51,100,2),('C-24',0,101,140,3),('C-24',0,141,500,4),('C-24',0,501,1000,5),('C-24',0,1001,2500,7),('C-24',0,2501,5000,8),('C-24',0,5001,10000,10),('C-24',1,0,19,0),('C-24',1,20,50,1),('C-24',1,51,100,2),('C-24',1,101,500,4),('C-24',1,501,1000,6),('C-24',1,1001,2500,8),('C-24',1,2501,5000,10),('C-24',1,5001,10000,12),('C-24a',0,0,50,0),('C-24a',0,51,100,1),('C-24a',0,101,500,2),('C-24a',0,501,2500,3),('C-24a',0,2501,10000,4),('C-24a',1,0,50,0),('C-24a',1,51,100,1),('C-24a',1,101,500,2),('C-24a',1,501,1000,3),('C-24a',1,1001,2500,4),('C-24a',1,2501,5000,5),('C-24a',1,5001,10000,6),('C-24b',0,0,19,0),('C-24b',0,20,50,1),('C-24b',0,51,500,3),('C-24b',0,501,1000,4),('C-24b',0,1001,2500,7),('C-24b',0,2501,5000,9),('C-24b',0,5001,10000,12),('C-24b',1,0,19,0),('C-24b',1,20,50,1),('C-24b',1,51,100,3),('C-24b',1,101,500,4),('C-24b',1,501,1000,6),('C-24b',1,1001,2500,9),('C-24b',1,2501,5000,12),('C-24b',1,5001,10000,15),('C-25',0,0,50,0),('C-25',0,51,100,1),('C-25',0,101,500,2),('C-25',0,501,2500,3),('C-25',0,2501,5000,4),('C-25',0,5001,10000,5),('C-25',1,0,50,0),('C-25',1,51,100,1),('C-25',1,101,500,2),('C-25',1,501,1000,3),('C-25',1,1001,2500,4),('C-25',1,2501,5000,5),('C-25',1,5001,10000,6),('C-26',0,0,300,0),('C-26',0,301,500,1),('C-26',0,501,1000,2),('C-26',0,1001,5000,3),('C-26',0,5001,10000,4),('C-26',1,0,300,0),('C-26',1,301,500,1),('C-26',1,501,1000,2),('C-26',1,1001,2500,3),('C-26',1,2501,5000,4),('C-26',1,5001,10000,5),('C-27',0,0,100,0),('C-27',0,101,140,1),('C-27',0,141,300,2),('C-27',0,301,1000,3),('C-27',0,1001,2500,4),('C-27',0,2501,10000,5),('C-27',1,0,100,0),('C-27',1,101,140,1),('C-27',1,141,300,2),('C-27',1,301,500,3),('C-27',1,501,1000,4),('C-27',1,1001,2500,5),('C-27',1,2501,10000,6),('C-28',0,0,100,0),('C-28',0,101,140,1),('C-28',0,141,300,2),('C-28',0,301,500,3),('C-28',0,501,1000,4),('C-28',0,1001,10000,5),('C-28',1,0,100,0),('C-28',1,101,140,1),('C-28',1,141,300,2),('C-28',1,301,500,3),('C-28',1,501,1000,4),('C-28',1,1001,2500,5),('C-28',1,2501,10000,6),('C-29',0,0,300,0),('C-29',0,301,500,1),('C-29',0,501,1000,2),('C-29',0,1001,5000,3),('C-29',0,5001,10000,4),('C-29',1,0,300,0),('C-29',1,301,500,1),('C-29',1,501,1000,2),('C-29',1,1001,2500,3),('C-29',1,2501,5000,4),('C-29',1,5001,10000,5),('C-3',0,0,19,0),('C-3',0,20,50,1),('C-3',0,51,100,2),('C-3',0,101,140,3),('C-3',0,141,500,4),('C-3',0,501,1000,5),('C-3',0,1001,2500,6),('C-3',0,2501,10000,8),('C-3',1,0,19,0),('C-3',1,20,50,1),('C-3',1,51,100,2),('C-3',1,101,140,3),('C-3',1,141,300,4),('C-3',1,301,500,5),('C-3',1,501,1000,6),('C-3',1,1001,2500,7),('C-3',1,2501,10000,10),('C-30',0,0,19,0),('C-30',0,20,80,1),('C-30',0,81,100,2),('C-30',0,101,140,3),('C-30',0,141,500,4),('C-30',0,501,1000,6),('C-30',0,1001,2500,7),('C-30',0,2501,5000,8),('C-30',0,5001,10000,9),('C-30',1,0,19,0),('C-30',1,20,80,1),('C-30',1,81,100,2),('C-30',1,101,300,4),('C-30',1,301,500,5),('C-30',1,501,1000,7),('C-30',1,1001,2500,8),('C-30',1,2501,5000,9),('C-30',1,5001,10000,10),('C-31',0,0,50,0),('C-31',0,51,100,1),('C-31',0,101,300,2),('C-31',0,301,2500,3),('C-31',0,2501,5000,4),('C-31',0,5001,10000,5),('C-31',1,0,50,0),('C-31',1,51,100,1),('C-31',1,101,300,2),('C-31',1,301,1000,3),('C-31',1,1001,2500,4),('C-31',1,2501,5000,5),('C-31',1,5001,10000,6),('C-32',0,0,50,0),('C-32',0,51,100,1),('C-32',0,101,300,2),('C-32',0,301,2500,3),('C-32',0,2501,5000,4),('C-32',0,5001,10000,5),('C-32',1,0,50,0),('C-32',1,51,100,1),('C-32',1,101,300,2),('C-32',1,301,1000,3),('C-32',1,1001,2500,4),('C-32',1,2501,5000,5),('C-32',1,5001,10000,6),('C-33',0,0,100,0),('C-33',0,101,500,1),('C-33',0,501,1000,2),('C-33',0,1001,5000,3),('C-33',0,5001,10000,4),('C-33',1,0,100,0),('C-33',1,101,500,1),('C-33',1,501,1000,2),('C-33',1,1001,2500,3),('C-33',1,2501,5000,4),('C-33',1,5001,10000,5),('C-34',0,0,19,0),('C-34',0,20,50,1),('C-34',0,51,100,2),('C-34',0,101,300,3),('C-34',0,301,500,4),('C-34',0,501,1000,5),('C-34',0,1001,2500,7),('C-34',0,2501,5000,8),('C-34',0,5001,10000,9),('C-34',1,0,19,0),('C-34',1,20,50,1),('C-34',1,51,100,2),('C-34',1,101,500,4),('C-34',1,501,1000,6),('C-34',1,1001,2500,8),('C-34',1,2501,5000,10),('C-34',1,5001,10000,12),('C-35',0,0,50,0),('C-35',0,51,100,1),('C-35',0,101,500,2),('C-35',0,501,2500,3),('C-35',0,2501,5000,4),('C-35',0,5001,10000,5),('C-35',1,0,50,0),('C-35',1,51,100,1),('C-35',1,101,500,2),('C-35',1,501,1000,3),('C-35',1,1001,2500,4),('C-35',1,2501,5000,5),('C-35',1,5001,10000,6),('C-3a',0,0,50,0),('C-3a',0,51,100,1),('C-3a',0,101,300,2),('C-3a',0,301,2500,3),('C-3a',0,2501,5000,4),('C-3a',0,5001,10000,5),('C-3a',1,0,50,0),('C-3a',1,51,100,1),('C-3a',1,101,300,2),('C-3a',1,301,1000,3),('C-3a',1,1001,2500,4),('C-3a',1,2501,5000,5),('C-3a',1,5001,10000,6),('C-4',0,0,29,0),('C-4',0,30,140,1),('C-4',0,141,1000,2),('C-4',0,1001,2500,3),('C-4',0,2501,10000,4),('C-4',1,0,29,0),('C-4',1,30,140,1),('C-4',1,141,1000,2),('C-4',1,1001,2500,3),('C-4',1,2501,5000,5),('C-4',1,5001,10000,6),('C-5',0,0,19,0),('C-5',0,20,50,1),('C-5',0,51,80,2),('C-5',0,81,140,3),('C-5',0,141,500,4),('C-5',0,501,1000,5),('C-5',0,1001,5000,7),('C-5',0,5001,10000,9),('C-5',1,0,19,0),('C-5',1,20,50,1),('C-5',1,51,80,2),('C-5',1,81,120,3),('C-5',1,121,500,4),('C-5',1,501,1000,6),('C-5',1,1001,5000,9),('C-5',1,5001,10000,11),('C-5a',0,0,50,0),('C-5a',0,51,100,1),('C-5a',0,101,300,2),('C-5a',0,301,2500,3),('C-5a',0,2501,5000,4),('C-5a',0,5001,10000,5),('C-5a',1,0,50,0),('C-5a',1,51,100,1),('C-5a',1,101,300,2),('C-5a',1,301,1000,3),('C-5a',1,1001,2500,4),('C-5a',1,2501,5000,6),('C-5a',1,5001,10000,7),('C-6',0,0,19,0),('C-6',0,20,50,1),('C-6',0,51,80,2),('C-6',0,81,140,3),('C-6',0,141,1000,4),('C-6',0,1001,2500,6),('C-6',0,2501,5000,8),('C-6',0,5001,10000,10),('C-6',1,0,19,0),('C-6',1,20,50,1),('C-6',1,51,80,2),('C-6',1,81,120,3),('C-6',1,121,140,4),('C-6',1,141,500,5),('C-6',1,501,1000,6),('C-6',1,1001,2500,8),('C-6',1,2501,5000,10),('C-6',1,5001,10000,12),('C-7',0,0,50,0),('C-7',0,51,100,1),('C-7',0,101,500,2),('C-7',0,501,2500,3),('C-7',0,2501,10000,4),('C-7',1,0,50,0),('C-7',1,51,100,1),('C-7',1,101,500,2),('C-7',1,501,1000,3),('C-7',1,1001,2500,4),('C-7',1,2501,5000,5),('C-7',1,5001,10000,6),('C-7a',0,0,19,0),('C-7a',0,20,50,1),('C-7a',0,51,100,2),('C-7a',0,101,300,3),('C-7a',0,301,500,4),('C-7a',0,501,1000,5),('C-7a',0,1001,2500,7),('C-7a',0,2501,10000,8),('C-7a',1,0,19,0),('C-7a',1,20,50,1),('C-7a',1,51,100,2),('C-7a',1,101,140,3),('C-7a',1,141,300,4),('C-7a',1,301,500,5),('C-7a',1,501,1000,6),('C-7a',1,1001,2500,8),('C-7a',1,2501,5000,9),('C-7a',1,5001,10000,10),('C-8',0,0,19,0),('C-8',0,20,50,1),('C-8',0,51,100,2),('C-8',0,101,300,3),('C-8',0,301,1000,4),('C-8',0,1001,2500,5),('C-8',0,2501,5000,6),('C-8',0,5001,10000,8),('C-8',1,0,19,0),('C-8',1,20,50,1),('C-8',1,51,100,2),('C-8',1,101,140,3),('C-8',1,141,300,4),('C-8',1,301,500,5),('C-8',1,501,1000,6),('C-8',1,1001,2500,7),('C-8',1,2501,5000,8),('C-8',1,5001,10000,10),('C-9',0,0,50,0),('C-9',0,51,120,1),('C-9',0,121,500,2),('C-9',0,501,1000,3),('C-9',0,1001,5000,4),('C-9',0,5001,10000,5),('C-9',1,0,50,0),('C-9',1,51,120,1),('C-9',1,121,500,2),('C-9',1,501,1000,3),('C-9',1,1001,2500,5),('C-9',1,2501,5000,6),('C-9',1,5001,10000,7);
/*!40000 ALTER TABLE `qtda_grupos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resultados_eleicoes`
--

DROP TABLE IF EXISTS `resultados_eleicoes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `resultados_eleicoes` (
  `codigo_eleicao` int(11) NOT NULL,
  `matricula_funcionario` varchar(15) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `codigo_empresa` int(11) NOT NULL,
  `razao_social` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `login` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `cargo` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `area` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `data_admissao` datetime NOT NULL,
  `qtda_votos` int(11) NOT NULL,
  `thumbnail` longblob,
  `foto` longblob,
  `efetivo` tinyint(1) NOT NULL,
  PRIMARY KEY (`codigo_eleicao`,`matricula_funcionario`,`codigo_empresa`),
  KEY `IX_codigo_eleicao` (`codigo_eleicao`),
  CONSTRAINT `FK_resultados_eleicoes_eleicoes_codigo_eleicao` FOREIGN KEY (`codigo_eleicao`) REFERENCES `eleicoes` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resultados_eleicoes`
--

LOCK TABLES `resultados_eleicoes` WRITE;
/*!40000 ALTER TABLE `resultados_eleicoes` DISABLE KEYS */;
/*!40000 ALTER TABLE `resultados_eleicoes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sindicatos`
--

DROP TABLE IF EXISTS `sindicatos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `sindicatos` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(30) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `email` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `endereco` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `cidade` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `responsavel` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sindicatos`
--

LOCK TABLES `sindicatos` WRITE;
/*!40000 ALTER TABLE `sindicatos` DISABLE KEYS */;
/*!40000 ALTER TABLE `sindicatos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `templates_emails`
--

DROP TABLE IF EXISTS `templates_emails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `templates_emails` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `template` text,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `templates_emails`
--

LOCK TABLES `templates_emails` WRITE;
/*!40000 ALTER TABLE `templates_emails` DISABLE KEYS */;
INSERT INTO `templates_emails` VALUES (1,'[CIPA] Edital do Processo','<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Edital - CIPA</title>\r\n    <style>\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"body\">\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"alert alert-good\">\r\n                                Edital da CIPA <span style=\"background-color: rgb(255, 0, 0);\">@ANO</span> - Gest√£o <span style=\"background-color: rgb(255, 0, 0);\">@GEST√ÉO</span>\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Aos <span style=\"background-color: rgb(255, 255, 0);\">@DATA</span>, <span style=\"background-color: rgb(255, 255, 0);\">@EMPRESA</span>, situada na <span style=\"background-color: rgb(255, 255, 0);\">@ENDERE√áO</span>, nesta cidade de <span style=\"background-color: rgb(255, 255, 0);\">@CIDADE</span>, atrav√©s de seu SESMT ‚Äì Servi√ßo Especializado em Engenharia de Seguran√ßa e Medicina do Trabalho - informa a todos os associados que na data de hoje tem in√≠cio o processo de constitui√ß√£o da CIPA ‚Äì Comiss√£o Interna de Preven√ß√£o de Acidentes ‚Äì de acordo com o item 5.38 da Norma Regulamentadora ‚Äì 05, aprovada pela Portaria n¬∫3. 214 de 08 de Junho de 1978 com altera√ß√£o da Portaria SIT n.¬∫ 247, de 12 de Julho de 2011.<br>\r\n                                            Todo o processo atender√° ao disposto na legisla√ß√£o citada acima.<br>\r\n                                            As inscri√ß√µes ser√£o aceitas do dia <span style=\"background-color: rgb(255, 255, 0);\">@IN√çCIO INSCRI√á√ïES</span> √† <span style=\"background-color: rgb(255, 255, 0);\">@FIM INSCRI√á√ïES</span>.\r\n                                            <br>\r\n                                            Os interessados dever√£o acessar o sistema no link <a href=\"link\"><span style=\"background-color: rgb(255, 255, 0);\">@LINK</span></a> para fazer a candidatura.\r\n                                            A elei√ß√£o ‚Äì vota√ß√£o ser√° realizada do dia <span style=\"background-color: rgb(255, 255, 0);\">@IN√çCIO VOTA√á√ÉO</span> √† <span style=\"background-color: rgb(255, 255, 0);\">@FIM VOTA√á√ÉO</span>.\r\n                                            <br>\r\n                                            Todos os eventos do processo ser√£o comunicados atrav√©s de editais fixados em locais de f√°cil acesso.\r\n                                            <br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RODAP√â</span>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Sistema de Vota√ß√£o Online</td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n'),(2,'[CIPA] Comunica√ß√£o ao Sindicato','<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Comunica√ß√£o: CIPA</title>\r\n    <style>\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"body\">\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"alert alert-good\">\r\n                                Comunica√ß√£o: CIPA\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Finalidade: Comunica√ß√£o de elei√ß√µes para CIPA<br>\r\n                                            Destinat√°rio: <span style=\"background-color: rgb(255, 255, 0);\">@DESTINAT√ÅRIO</span>\r\n                                        </td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Prezado,<br><br>\r\n                                            De acordo com a Norma Regulamentadora - NR 5, aprovada pela Portaria n¬∫ 3.214 de 8 de junho de 1978, baixada pelo Minist√©rio do Trabalho, informamos o in√≠cio do processo eleitoral para representantes dos associados na Comiss√£o Interna de Preven√ß√£o de Acidentes ‚Äì CIPA da {3} situado na {4}, na cidade de {5}, a ser realizada em escrut√≠nio secreto conforme cronograma abaixo:<br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@CRONOGRAMA</span>\r\n                                            <br><br>\r\n                                            Sem mais no momento.\r\n                                            <br><br>\r\n                                            Atenciosamente,\r\n                                            <br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RODAP√â</span>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Sistema de Vota√ß√£o Online</td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n'),(3,'[CIPA] Inscri√ß√µes para CIPA','<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Inscri√ß√µes para CIPA</title>\r\n    <style>\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"body\">\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"alert alert-good\">\r\n                                Edita de Inscri√ß√µes para Membros da CIPA <span style=\"background-color: rgb(255, 0, 0);\">@ANO</span> ‚Äì GEST√ÉO <span style=\"background-color: rgb(255, 0, 0);\">@GEST√ÉO</span>\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Aos <span style=\"background-color: rgb(255, 255, 0);\">@DATA</span>, o(a) <span style=\"background-color: rgb(255, 255, 0);\">@EPRESA</span>, situado(a) no(a) <span style=\"background-color: rgb(255, 255, 0);\">@ENDERE√áO</span>, nesta cidade de <span style=\"background-color: rgb(255, 255, 0);\">@CIDADE</span>, convida seus associados a realizarem suas inscri√ß√µes para elei√ß√£o dos membros representantes dos Empregados da Comiss√£o Interna de Preven√ß√£o de Acidentes ‚Äì CIPA ‚Äì Gest√£o {1}, de acordo com o item 5.40, al√≠nea a, b e c, da Norma Regulamentadora ‚Äì n¬∫ 05, aprovada pela Portaria n¬∫ 3.214 de 08 de Junho de 1978, com altera√ß√£o da  Portaria SIT n.¬∫ 247, de 12 de julho de 2011.\r\n                                            <br>\r\n                                            AS INSCRI√á√ïES PODER√ÉO SER REALIZADAS A PARTIR DO DIA DE HOJE, <span style=\"background-color: rgb(255, 255, 0);\">@IN√çCIO</span> AO DIA <span style=\"background-color: rgb(255, 255, 0);\">@FIM</span>\r\n                                            <br>\r\n                                            Os interessados dever√£o se cadastrar no link <a href=\"link\"><span style=\"background-color: rgb(255, 255, 0);\">@LINK</span></a>.\r\n                                            <br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RODAP√â</span></a>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Sistema de Vota√ß√£o Online</td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n'),(4,'[CIPA] Rela√ß√£o de Candidatos','<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Candidatos - CIPA</title>\r\n    <style>\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"body\">\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"alert alert-good\">\r\n                                 Rela√ß√£o de Candidatos Inscritos da CIPA <span style=\"background-color: rgb(255, 0, 0);\">@ANO</span> Gest√£o <span style=\"background-color: rgb(255, 0, 0);\">@GEST√ÉO</span>\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Ficam convocados os associados, estagi√°rios e tempor√°rios do(a) <span style=\"background-color: rgb(255, 255, 0);\">@EMPRESA</span>, <span style=\"background-color: rgb(255, 255, 0);\">@ENDERE√áO</span>, na cidade de <span style=\"background-color: rgb(255, 255, 0);\">@CIDADE</span>, para a elei√ß√£o de seus representantes na Comiss√£o Interna de Preven√ß√£o de Acidentes - CIPA, de acordo com a Norma Regulamentadora - NR 5, aprovada pela Portaria n¬∫ 3.214 de 8 de junho de 1978, baixada pelo Minist√©rio do Trabalho, a ser realizada em escrut√≠nio secreto no dia 25 de abril de 2017.<br>\r\n                                            Apresentaram-se e ser√£o votados os seguintes candidatos:<br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@CANDIDATOS</span>\r\n                                            <br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RODAP√â</span>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Sistema de Vota√ß√£o Online</td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n'),(5,'[CIPA] Convite para Vota√ß√£o','<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Vota√ß√£o - CIPA</title>\r\n    <style>\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"body\">\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"alert alert-good\">\r\n                                Edital de vota√ß√£o para membros da CIPA <span style=\"background-color: rgb(255, 0, 0);\">@ANO</span> ‚Äì Gest√£o <span style=\"background-color: rgb(255, 0, 0);\">@GEST√ÉO</span>\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Aos {2}, o(a) {3}, situado(a) no(a) {4}, nesta cidade de {0}, atrav√©s de seu SESMT ‚Äì Servi√ßo Especializado em Engenharia de Seguran√ßa e Medicina do Trabalho - INFORMAMOS A TODOS OS ASSOCIADOS QUE O PROCESSO DE VOTA√á√ÉO DA CIPA ‚Äì COMISS√ÉO INTERNA DE PREVEN√á√ÉO DE ACIDENTES OCORRER√Å DO DIA {5} AO DIA {6}, de acordo com o item 5.38 da Norma Regulamentadora ‚Äì 05, aprovada pela Portaria n¬∫3. 214 de 08 de Junho de 1978 com altera√ß√£o da Portaria SIT n.¬∫ 247, de 12 de Julho de 2011.<br>\r\n                                            Para a vota√ß√£o, acessar o link <a href=\"http://link\"><span style=\"background-color: rgb(255, 255, 0);\">@LINK</span></a></p>\r\n                                            <br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RODAP√â</span>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Sistema de Vota√ß√£o Online</td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n'),(6,'[CIPA] Apura√ß√£o dos Votos','<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Apura√ß√£o de Votos</title>\r\n    <style>\r\n\r\n        .body {\r\n            -webkit-font-smoothing: antialiased;\r\n            -webkit-text-size-adjust: none;\r\n            width: 100% !important;\r\n            height: 100%;\r\n            line-height: 1.6;\r\n            margin: 0;\r\n            padding: 0;\r\n            font-family: \"Helvetica Neue\", \"Helvetica\", Helvetica, Arial, sans-serif;\r\n            box-sizing: border-box;\r\n            font-size: 14px;\r\n        }\r\n\r\n        .body {\r\n            background-color: #f6f6f6;\r\n        }\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"body\">\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"alert alert-good\">\r\n                                Ata de Apura√ß√£o de Votos CIPA <span style=\"background-color: rgb(255, 0, 0);\">@ANO</span> Gest√£o <span style=\"background-color: rgb(255, 0, 0);\">@GEST√ÉO</span>\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Aos <span style=\"background-color: rgb(255, 255, 0);\">@DATA</span>, no(a) <span style=\"background-color: rgb(255, 255, 0);\">@EMPRESA</span>, situado(a) no(a) <span style=\"background-color: rgb(255, 255, 0);\">@ENDERE√áO</span>, na cidade de <span style=\"background-color: rgb(255, 255, 0);\">@CIDADE</span>, diante a apura√ß√£o ficou constatada a participa√ß√£o superior a cinquenta por cento dos empregados na vota√ß√£o, eximindo-se a empresa de nova vota√ß√£o, de acordo com o item 5.41 da Norma Regulamentadora ‚Äì 05 aprovada pela Portaria n¬∫ 3.214 de 8 de Junho de 1978 com altera√ß√£o da Portaria SIT n.¬∫ 247, de 12 de Julho de 2011.<br>\r\n                                            A apura√ß√£o dos votos ficou aberta para a participa√ß√£o de qualquer associado interessado e chegou-se ao seguinte resultado:<br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RESULTADO</span>\r\n                                            <br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RODAP√â</span>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Sistema de Vota√ß√£o Online</td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n');
/*!40000 ALTER TABLE `templates_emails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidades`
--

DROP TABLE IF EXISTS `unidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `unidades` (
  `codigo` int(11) NOT NULL AUTO_INCREMENT,
  `codigo_empresa` int(11) NOT NULL,
  `cidade` varchar(100) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `estabelecimento` varchar(200) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `codigo_grupo` varchar(8) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`codigo`),
  KEY `IX_codigo_empresa` (`codigo_empresa`),
  KEY `IX_codigo_grupo` (`codigo_grupo`),
  CONSTRAINT `FK_unidades_empresas_codigo_empresa` FOREIGN KEY (`codigo_empresa`) REFERENCES `empresas` (`codigo`),
  CONSTRAINT `FK_unidades_grupos_codigo_grupo` FOREIGN KEY (`codigo_grupo`) REFERENCES `grupos` (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidades`
--

LOCK TABLES `unidades` WRITE;
/*!40000 ALTER TABLE `unidades` DISABLE KEYS */;
/*!40000 ALTER TABLE `unidades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario_empresa`
--

DROP TABLE IF EXISTS `usuario_empresa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `usuario_empresa` (
  `codigo_empresa` int(11) NOT NULL,
  `login_usuario` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`codigo_empresa`,`login_usuario`),
  KEY `IX_codigo_empresa` (`codigo_empresa`),
  KEY `IX_login_usuario` (`login_usuario`),
  CONSTRAINT `FK_usuario_empresa_empresas_codigo_empresa` FOREIGN KEY (`codigo_empresa`) REFERENCES `empresas` (`codigo`),
  CONSTRAINT `FK_usuario_empresa_usuarios_login_usuario` FOREIGN KEY (`login_usuario`) REFERENCES `usuarios` (`login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario_empresa`
--

LOCK TABLES `usuario_empresa` WRITE;
/*!40000 ALTER TABLE `usuario_empresa` DISABLE KEYS */;
/*!40000 ALTER TABLE `usuario_empresa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `usuarios` (
  `login` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `nome` varchar(60) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `perfil` varchar(20) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `funcionario_id` int(11) DEFAULT NULL,
  `senha` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `codigo_recuperacao` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  PRIMARY KEY (`login`),
  KEY `IX_funcionario_id` (`funcionario_id`),
  CONSTRAINT `FK_usuarios_funcionarios_funcionario_id` FOREIGN KEY (`funcionario_id`) REFERENCES `funcionarios` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES ('admin','Administrador Master','Administrador',NULL,'t0BVNf68/gumXktqrpAgNg==',NULL);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `voto_branco`
--

DROP TABLE IF EXISTS `voto_branco`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `voto_branco` (
  `funcionario_id_eleitor` int(11) NOT NULL,
  `codigo_eleicao` int(11) NOT NULL,
  `data_horario` datetime NOT NULL,
  `ip` varchar(15) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`funcionario_id_eleitor`,`codigo_eleicao`),
  KEY `IX_funcionario_id_eleitor` (`funcionario_id_eleitor`),
  KEY `IX_codigo_eleicao` (`codigo_eleicao`),
  CONSTRAINT `FK_voto_branco_eleicoes_codigo_eleicao` FOREIGN KEY (`codigo_eleicao`) REFERENCES `eleicoes` (`codigo`),
  CONSTRAINT `FK_voto_branco_funcionarios_funcionario_id_eleitor` FOREIGN KEY (`funcionario_id_eleitor`) REFERENCES `funcionarios` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `voto_branco`
--

LOCK TABLES `voto_branco` WRITE;
/*!40000 ALTER TABLE `voto_branco` DISABLE KEYS */;
/*!40000 ALTER TABLE `voto_branco` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `votos`
--

DROP TABLE IF EXISTS `votos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `votos` (
  `funcionario_id_eleitor` int(11) NOT NULL,
  `funcionario_id_candidato` int(11) NOT NULL,
  `codigo_eleicao` int(11) NOT NULL,
  `data_horario` datetime NOT NULL,
  `ip` varchar(15) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  PRIMARY KEY (`funcionario_id_eleitor`,`funcionario_id_candidato`,`codigo_eleicao`),
  KEY `IX_funcionario_id_eleitor` (`funcionario_id_eleitor`),
  KEY `IX_funcionario_id_candidato_codigo_eleicao` (`funcionario_id_candidato`,`codigo_eleicao`),
  CONSTRAINT `FK_51babfde6ae84679b35e093401057693` FOREIGN KEY (`funcionario_id_candidato`, `codigo_eleicao`) REFERENCES `candidatos` (`funcionario_id`, `codigo_eleicao`),
  CONSTRAINT `FK_votos_funcionarios_funcionario_id_eleitor` FOREIGN KEY (`funcionario_id_eleitor`) REFERENCES `funcionarios` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `votos`
--

LOCK TABLES `votos` WRITE;
/*!40000 ALTER TABLE `votos` DISABLE KEYS */;
/*!40000 ALTER TABLE `votos` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-01-09  9:32:35
