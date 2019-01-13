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
INSERT INTO `__migrationhistory` VALUES ('201901091010371_InitialMySQL','CIPAOnLine.Migrations.Configuration',_binary '�\0\0\0\0\0\0\�]\�n;��_`\�A\�\�\��\�$\�\�L\�\��\�I\�\'^;1�N�%\�nL�[��e$g�O��H�\n\��\�O��ݒr�\0�\�$�d�c�HV�\���\�\�_7�\�fy�&�\�\�NN\�3��\�u�<��\��?�<��\���\�\�ޮ7_g�m�e>V2\�_\��b�j�\�W�tC�M�\�\�<�/NV\�fA\�\�\��\�\�_Ϟ-(#1g�f��\�]RDZ�`?/\�dE�Ŏė\�\�y�\�TTgɆ\�[���\�\�\�?%���ԙ\��8\"�!74��\�H��)X3_}\�\�M��\�\�͖} �\�o[\��ݓ8�M�_�\�m{r��\�ɢ/ؒZ\��\"\�8|��a\�B.\�\�\�y\�:Ƽ��\�ŷ�\�_\�\�W\�W\�&�m���@��\�E���6�H���Y~\��\0T�c���\�e�uBwEF\�fW��8Z��~����&��]�e\�ei\��\�*K�4+�]\����\�\�n�\�gs��������g���,TQ\�&6-\�K��M�\�\��\�w\�W�n7\���Dl�\"E�c??�Β��v\�m\�]�\�jIӘ�ę\�k\�tM\�}R�x\�L���\��\�\�\�FuHr$��<EN%�\�(]ӸJ\��m-N��eWa\�v\�]�n�Ӹ-�\�X~&\�-XSm��t��ZZv?���4bslq�C�Lm4�Ii7�j�٢�ZI\�p\�E~TE�*5|��\����\nܐo`�x)/�t�sKW츗0oٷ\�(��.IU\��r�\�\�M�f�W�Ќt}E\n�1\�\�c�\�UF�J�\�\�ܲe.�,)<�����ya�\�$YGkR8\�\�؞f�]�b�,J߯�\�f=\�\�\�4Z��B�p\n�K-��\��Y\�\�vtwi\�}\�h}f;g��\�#�V�\�\\\�\Z�_\�m�>�i�S�\�\�\�\\r\�\�>��k��\�ݘ}h\�z\�9\�n5Ui+�ŵ}\��6r\�H;\�J[�l�\�MD\�.S`�)Jˤ\�A*5�?q\�S8j�\�_��_ӊ�&�\�$�\nb=�˔W�\0\��˗VZ���\'r0�)k+��\�k:u\�2��B?&���_i^<�١\�qV0傼g�t��Q�zGW�\�GR\0\�fzA�\�isQ�cL`�\��c��\�MĦʊ�\�۔e�\�\��N\���=��\"K\n�Fc�N�\�u^^2h�\�gS�ا�M䲸6�[��|3�\�\�\�ц\n�\\�\�\�G\�\�6�ڼ:mX�\�ڤ����\��a\�U��e�:�SSu\�⪄^Ӝ�\�Nha�ځIm\'�Gi-�ѵ͜�\�7�K�.�>�\�wh\\�Vw=�\�d�\�*�v�d$Yi6u:4\�j*���ڄ4���\�T٫\�\�4\�Om���\�M>�*T�N?���;E$��\�T�H\�3\�l\��u�kN%������>\�U\�}y�!�QT\�|rӄd��b�A���C.�.�cOd�\�\�D&�K��\�5�\�\\X(��qV\�\�\�c\�\�e|u�n�HmY^W\\caJ8\�uAW����.	\�\�.&�\'>Qi4�\�6��Q\Z4?�2\����>��\�a\�-�$�\�j\�\�CTr�Q�V���\�\�|���8y�e?��>\�\���Y�pt��\�<�21%_\�\�ޤw����\�0\�m\���Dl\���\�\�Ἧ\�d\�\�psg}&׊C[�|pC�dm+\�<\�\�ޥ\���g)\�t�\�r6ݝ��\����&�\�`שZ7Y\\9l��-\�5�v�\�\�;\�6q\��ab�\�\�k���M;5�\�l\�B\�=�\�Y\�5���7\�*\"!.\�{�/�NsЈ�>w� ��Gr�A\�\n\r76���\�Fyta ��\�\�+�\�k��\�T��\�0(r4yԩ\�a�Z]\�Վ}%+\�MxhC�f\���A&0B��5�1\�HVd�g�\�R�;\�C���!ڸ�\�j\�i�=��\"\�`�諾k\�bT\��s�i�t\'ϛ�\�T\�;\�^\��H�Z��u\�,oD\�u;1� g\�8�s@\�\�I$.\�\�\�\�?�<�l|[\n��\Z�T\�\�,\�\�j]^��v�\�<\�\�\�l�|^\�-\�\�\�wAV�;6qv�2\�\\�:\� g�2h6\"Vg�$�\���}�eFo\�\�&3�r�5~���h\�rSN\�\�-�J	qMI�^9_�ߑ��Ҽ0���\�\�\��\�\�\�8;�\�[Wg�\�V��kYm�6dN˦\�n3[.}4�6*�\�U\���㳟9\�{�I\�k\\�\Z\�\�Ʊ\�08nh�E�Gl�\�*}�!WH3�@��34\�\�$^+� y\�3z�x�}��ˢ\��qN<\��\�^ΉǑ\�o�5\�\�j��My�ر9\�t۲\�L�\�\�&�v�\�D]\�\�D\r��\r\�g(; y��\���dvZb��\r`\�i��<3��o*\��g\�Ԏ�j�*%\�\��Hţ]���j�\�\�`X�\�\�A\�\�2x8 ��~H4�=\�t{[W םQ�\�\�\'��6\�t��\�\�T\�.\�z#V��M�{�wt\�Ic3:\�YĆ���<)\�ËG5�\��\�\�\�b�\�x\�\�2L����l�Xk\�ʯ�\�H���\�I+�\�J��T\�ƛ�\�I\���-AQR�\���U�%�UW�\�����.9\�\r\�ҤpVL�o�u\�U(\�\�Ĳ��%=\��,\"x�h\�b\�p`S�;\�TP{\�\�ؤ��\r��c�ڣ\�8^�7}X\�aȳ\r�\�\�uh�u۸�j��\�\�v-���!f�\�M�=\�\�\�ro��`\0�\�0\�\��\�\�c�8h��\�`:���wo\"Ug\�р�K��6��P}�n/��6�6N\�(��|*�\0����\�\��\"\�p\�/8h0l\�`C])ЌH��\�$(��\�،)\�\�J �\�Շo\�\�J\�E�4-8PxK\�J�\�\�ՀPBᰎ@Fs^��\�\�\0��\0NH\�l\�M�$�\�,x\�$S��\�%}W\'�VzV\�\�\'\� �\r�\�[��\�-\�^b\�|L\�@Npi\�2�4<>H)\�\�:��K\�V���\�a�C��]1\�)�\�6\�Q\�\�\n\�\�\�\�\�hi\Z1ѾD\�d��6Ν~�W\\�-F��1V\nZHU�\�\�\�wx\�a\r�V3�\�\�Xd9�\�F\�\�q��\n5)\�Y\��鏥\Z\�؃Py\�p5\�0i/x�\�g�\�\�|i�����@؛R\�\�V�-8�\�	x,�ۭ��?ؓd��Z�,\�or R�@vS��P&X6!F:\�w\�\n0��n�1�`<�o���7,<\�ȼA�a��g�1�\�k\�r\�5�h0��*�\�vL$�`��j\��\�&~\�*\�%� �׆��	�Kb\�\� \�\�U1X�D2f�}\�{�.`c��\nЏ3\�?�\'ӦZ\��6L$��ǲ�+�l\�[�\�IB�\�-�(\�\�w\��\�w�a��\�ؐ�ݤ��W\�y\�C\��^\�T�\�Ԓ����\�\"��fw\�&=x�2����]\�\�\���\�6pQ\�1�.��׾~�K�1>�=M�1\�\�N�+\�֫\�ޚ�\��~\�H\�&\�\�\0�\�;�\�@�w\�;\��\�\n\�S<\�-;Ҁ��s��\�߶i�%\'\� �]�MN�-���\'��O���s@�=_Y����Y��<���|\�i㩜7N\��\�\�nh\�:xK���|\��\�b�\n�D�s B ה\��]�\�\��#\rt�7\�2\�5 Jf���s�ґ\�\��\�\n=D�VI4�ޫ�X�r��,*�r)ZKw��\�/`�$��\�4�\rU�to��lA\"\�$��T�ٞC�ޥ0\�\'\�\�\�&@n\�&\n�[�%�6Ջ���4ګ�\�\�#G\�˟%(u�\�\\3�\�c\�nWQC�,*�\����*$\�)�>芍XU\�\\��U\�%�\�*Iꫡf\\f~0iC�����ң,\�ց8b�\�(1b!rKx�\0�Q���\rp=�Z\r\�\��Ff��;\���?�\�WK�v�Ø��a��;P�:R\�������\�0�݇\�E/�5\�\�x@�\�\�Wb\�\�+��\�\�\�,v�\�C���N]\�gICú��N����0�H\�(q\�g�i�9Mj�\�Z	bp����;���\����Vb\�(�\�\�\��F\�h�cpKn�\�\Z�2z��\�2\Z�6�#��D\��G�%�}&��%0��\�Y\"�1-�݆O7�0�,��BݮS?�d\��9�Й#� [�w[\�\'�\�ѻa\�B�v5;u;��G\�\�.\�\�v=� ��\�\�PLIn2�f�;\�\��94�:��\�\�\�\�[#>/��V!�\�5�\�\�\�j\�l׽߲q\�xz\�\n\�\�^\�b/s�;30���P���D�E��:px�d\Z��\�\�\Z\��JUr\�.\�W�-�\�g�f�R{�\�\0�0b�M0���\��ɭ\�|�\�-\���[\�\r��\�8\"D}\�K\�\�jm�`7:���\�;`���!v�B_�6�\\��\r��f�\� G5\�\�H\�r��힯LQ��8J��\��\��\�\\@kx\Zk(�g�ֵ�jҝ`\�f\�`By+A\�\�\����\��$�]\�e��	\�l\�ȷ�ُ�M\��6>{g�ҥ�-nV�tC�g�eE�\�\�e<�M�$\�m�<\�}\�\�\�\�fKV\�ɟo泯�8\�_\��b�j�\�+\��\�&Zei�\�\'�t�`Ro������g\���\�b%\�,٦���\�\�J��\�}eyQ>\�vG\�\��덒��\�Ana\�J0�u�ڋٶd�ws�<A`�\�\�����|O�\�,�n\�0\n�\�͊\�$ӽs�ƻMR\'���\�#\�\��\�Q,86N���l\�VyR��\�\�4eґ�.ßH�B4�6qIZ>�6��/��VK�l!�����%ib\� ��p#%�\��xhE\�\�1\n��\�_\�\�jo#\�\�YM٣�\0ի&ʄڨ��	�oШ�ʯ����Ox2O������\��\�a�\n5e1\�J\�ix\�s\�\��F\�n\���bnP8\�05�5��)?\�\�\���	c���*0k�\�$��0��p��\'f�9~D_���ޤ��\�\�4�l�!;�BK���M\�\�=�r\��>�V�D�\����7r\�\�\�4�[*$\�Dgt\�ǖ�a\'i�\�P �\�<\�LD�S2�l��D��\'�\0\�\r�b��>�8%�#h�		���\�@�I��\��&\"yu&.\� �y���O�=\��-�h�>��7P�\�K\�P	_�Y�+8\�2QB\Z��}?<�ћ}$�]�\�Xʣ�I�>\�\�\�\�\�˃\�B��8\r�.C���hm\�q���Y�\�\�D0�t\�6���\�\�\�@Z\��\�\�|Tן�F2E֟\�i�gT\�\n���\�\�\�څ\n\�lI�\�F�#ɻ�\��	�\�p\�V�*\�Lf�Sk��!��q�7\�]&�)�?9H�\�\�\�.Q�W��F\�uW��`��\�F\�J��q\\�\�IzS^)J�$$\�0i\�]���v&�\�\"u�`��ٽ<\r�ͷ=�\�\�\�Q�y�\�U�]\�Վ}%ءZƧ�U��`*V\�\�>H͂)L��\�!_��\�\�q\0;��װ��\�=,Rp��\�0�\��\�iho\�\�[�I��y�\�9>�G�{\�AS˪ϵ\�ۑRyo\��\0\���Mq0E����\�C\�m\�0�M0?c��	\�1�\\|ĸ(3\�\��t��_{�x��$�~��X)�\��47�\�4/ �\�.\�`��\����\�tf�B\�\�ry\�g\��%z���	\�=}�q~\�q~Y\Z\�5	\�\�V��9\��\�C��Ɗ{e�o\�0��\�X\�.M\�\�iǈ\�H\�4�++\�WA٣8ۡ��d�&9y��\�w\��\�\�`\�\�\0+9.xGY�\� \�-\�\�\�\�\0^LQ9\��R\�ݤ|O\�\�#4\�f\�\��x\�q\�yEd�\�-q3X>\��\�~t\0c�\���J��\�\0�\�tǎ�n\�\�␜#D_G𾖋neq-\�\�F�_�\�\�sS\�E\�xX*�\�=����\�\�\�B4��\�^j��/\�\�\'���7;\�\�D\\*���\�YɌ\�D	0���>nï	eb\�J\�K�!\0P��\�,��i�t�;�\�\�wXpj��V�(W]\�?fٙ�\�2���?E\�ʑ�\�\�o�I�~R�yGL��9.I\�3\�\�s�/����|r:��\�\�kw�\�M���6��\����\�4]orqw\�\�J����[\�\�\�_\�x|�O���\��M�R@�\�g��3	�bMu\�\�\�d�G��1�g[���\��U�~5{��K��O�O\�W�\�\�\�g�\�\��<�lD糏�8&w���=�s5D�Ԯ�Cu�\�\�4v�!�E\�t�v�d@Whr���-%^\�\�zw\�u�R\�\�\0\0\�\�!޼\�N+0/� N<�M�Ǟ�C���l�\�ԩX<p�UN\� �\��F�>qa;l\�	t: :��r�C,\�!�\�\�8�rG\�\Z\"�\�\�ѹn\r�\�&@yD{�\�U�W�˩s\r�\�3�0��u�\�!<\�2R�^�\���2�qo}E�r\'_�Ҵj�3�B\"6$n�خ]>�uy֬\�\�_��?��\�c�\\\�캬\�喻\�~��Ͽ$\�o;���1ZZٟ�tn�\�\�TP)>϶\�mV`\�\n\�Oܗe�I\�І\�[ڡ�\�>�\�\�O�p�\�^�\�\�\�N\�f9�9/��c/t�\'\�9�\�8�z{�R��Ve݄\�\�s��\��ֲ���4\�\��J�fX[\�~�Y\�r�>�5T�\�\�\�\"/\r�55N\�v\�Tw`fFJ\n\�LԟѸOty��a�[z�p���6;��r�\�\�Fx�P�6s�op#�&4v�\�\�Ɩ\�~(��6��ӵ�����YF%)YH�\�\�?\�\�[6\r/���\�;Zp�ſ.<D�n\\Ǉl\�Q\��ք\�4y��ӻP�{\�%�\�Um��\�JC6$�ф�@\�l3�A�\n��I\�m\�c��;\�)N��fu\�vVC\�ړ\�iݞC\�h\��Dm��K\�A�����w�\���ylk̺����\0��\�>��\�4\���~iط{ЕGCe\�,E�2\�6�{4\�`\�L-��9\�t�\�,���:]̴\�u���\��\����csQ�=�s\�v��\�\rd�\"�ﵵ�\��\�~\�\�C{\0rN\��\�U�Y\�|\�O\�\Z�z\�\�\0i鈭��8\"0#,\"���)��\�a\�F9\�p=��\"\�xLk/P\�\�i\�m&�v���<at\�O[;ۗ[C\�\'�;ݕs�}1\�N\�c\���\�\�K�h@\"�\�1C^\�G\�!7���\\��_�abL\0ղ��\��jkBG�\n\'\�~��\���M���\�.ZG�үv=\�\�6`4�\�\�v\�\�±d,��3�\�\�\nu�F�1\�d�\�\�\�e�\��&P@\�QKq��h�䱙z\�v0[\�=\��a#\��j�wv�C��b��\�r������\\=�\�|�\�\�E�����\�\n_z�K2OLI\��I!\� \�\�k\�W_0͵\�H�F��\�\"\�\�-��NH��璿M9\�\rݖ:R ݵ��\r]tuH\�\�\�\r�Y_��ηu�w!2�:��N�<A\�\�(	?j`ܧ\�`���\�n\�@�<��wj��ʴ�\r�\���/\"DU\�0\n.u\���.�z�h��XC\��\�\�\Z>\\\�\�,\�C\��ފ\�I�\�;<-��x�\�QVQ7\�*�\���K���\Z���=\��5�\�/��<��\�(�EG{Lq\�1\�y\���&\�\�GOJG��\�\�p�`z\�\�\�f\\8\�.N�T\�>/vǃ\�ș\�\�~Q	�8ɰ�w^v����?wrb��S�ͫ��f�	4�D�O��\��t���\r��AB| +jݷ\�����������k\�~sP\�\�|�ڸ���\�g\�\��ծ x\�\�}�\n�\�7�.\�<2.8�1s\'\�/`�\�\�R\�cA:Ny\�j���\\\�\�R1,�.-P�u��\�r*��i\�U=x�\�qW��y}�\�|r\�?�\'@ЇXI~`�O�\�\�h\�˕[YD\�r\�yy�</;ąҳ\�S�}t��jJ\�M��bw�\n��\��\�	~w\�yU\�@h?�gڧ~X\"p`�X.\�{��8(Ia�PKx�\�D\'\�\rO+B\�\�\��(�~0g<�r(��X\�x�\� �\�-j&�\���\�vb+�k۽\�q�\��\�D�\0\n<%�����`q\"�X\�\�����p\�l�q�0�҈\�{�\�cJL%�X<=5�{��������\��\�z#��P�\'���M�t�\�����<�#�ڱ�����:_/>\�Q\�׷\�Y�ğz?t\�\�\�\\\�;\�\�8/\�\��\�\��\0\��\�.�&��\�GR/J���\�{���q\�&�E� �y��ɯ�H�.��e���\����P\�\rܽ\�w\�\�*�+n\�T\�|�*�x�)s^�\nu.\r����`Y\rw�TåAլz�l\�ZD/?�B1��n�3_fm^sC�U]��K����\"b�_o�T\��w�v�d�\��)�\��6|�Ж�f�*�t��\�W$_V��\��\�k�\Z�T�>\�\�bTڥL�6�:\�L��\�T\�w)�\��щW�闎_uϖ��\�\�m��T\�$��J��-�pgn\�<Y5��m���X˻&��\"�hI��O�*�\�U˗�\�_=�P*T�@\�fm�|i-ոݵR+�U\�m%-fQ�r���MgQ�h�\�ŚR+蓠\Z\��a\���X�\�\0H��\�B�U�s�Y\�.�\�\ZلFVEV�T�2�RN��25&ˌ\�̫h�\�-\�f�\�y�EQ�5�=�\�J�Կ�\�A�\�\�G��[F)	\����\�V���Ya}�\�%X�\�E��:s��\Z\�c\0d\��\��Z\0Xb\n\�\0�q��*{�ϧ�|4��h����^���hU.�x��q\�=�%\�\�X\�\�\�g=\�l)e?]V]\�5�\�\�}\Z\�u�N\"�\�@Gm\\���\�s\�x\��^\�*\�\��\�\��ے*U���\�Tt5\�\�\n!\�\�\�> 硊�\�\�.�j�\�ؗ\�0\02E���1\0rE4Lw\�� �\�{L�a]V�\��]\��\���ȹ�L�N���xE\�)�;\��,��\�\������\�<��i\���ކM�+\�h�\�cvO�7A:��J	��P������\�\r\�fLu~�Gv\�n\�|4��ѵ ȸ\�GN<��BKgo\��\�2�d�f���	�\�uO5]4�>��z\�P\�?\�nMR\�Y\�u\�{�n���@w\�\�X��0v\�SP�\�]\�*����\"l�ɵ�FcU8\�<V,���������\�\�%j87y\'�־.\�6ҁ5�\�\\\�-�^\�\�Z�\�@g�ԥ�-\�K�\��\�4I�@\�*H\��z��\�%\�p��74�zg�fBW��U�\�}r���_R�\�,\�C��\�R��\�ɪ`\�+�\�Q�0�ݒxW�䎮\�\'�v\�vW�.\�\�]��gFi:���l���\�Ӷ���\�kf����_vQ�\�\��x�!Qڤ5O�cY�O=|\�(}LKB\r�:S��`=��ܐ\'\�Ӷ/9�@\�\����i�1�\���7y\�\�&oh�\�\�O�\��\�\�\��v�.j��\0','6.2.0-61023');
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
INSERT INTO `etapas` VALUES (1,'EDITAL DE CONVOCAÇÃO PARA ELEIÇÃO',2,1,NULL),(2,'FORMAÇÃO DA COMISSÃO ELEITORAL',3,1,NULL),(3,'ENVIAR CÓPIA DO EDITAL DE CONVOCAÇÃO AO SINDICATO',4,1,NULL),(4,'INÍCIO INSCRIÇÕES CANDIDATOS',14,1,NULL),(5,'TÉRMINO INSCRIÇÕES CANDIDATOS',3,1,NULL),(6,'PUBLICAÇÃO EDITAL DE INSCRIÇÃO DE CANDIDATOS',1,1,NULL),(9,'REALIZAÇÃO DA ELEIÇÃO (VOTAÇÃO)',20,1,NULL),(10,'REALIZAÇÃO DA APURAÇÃO',3,1,NULL),(11,'RESULTADO DA ELEIÇÃO - ATA DA ELEIÇÃO',1,1,NULL),(12,'CURSO PARA CIPEIROS (DATA MÍNIMA)',20,1,NULL),(13,'CURSO PARA CIPEIROS (DATA MÁXIMA)',4,1,NULL),(14,'TÉRMINO DO MANDATO ANTERIOR',2,1,NULL),(15,'REALIZAÇÃO DA POSSE - ATA DE POSSE NOVOS MEMBROS',1,1,NULL),(16,'ORGANIZAÇÃO DO CALENDÁRIO REUNIÕES MENSAIS',1,1,NULL),(17,'EDITAL DE CONVOCAÇÃO PARA ELEIÇÃO',2,2,NULL),(18,'FORMAÇÃO DA COMISSÃO ELEITORAL',3,2,NULL),(19,'INÍCIO INSCRIÇÕES CANDIDATOS',14,2,NULL),(20,'TÉRMINO INSCRIÇÕES CANDIDATOS',3,2,NULL),(21,'PUBLICAÇÃO EDITAL DE INSCRIÇÃO DE CANDIDATOS',1,2,NULL),(24,'REALIZAÇÃO DA ELEIÇÃO (VOTAÇÃO)',20,2,NULL),(25,'REALIZAÇÃO DA APURAÇÃO',3,2,NULL),(26,'RESULTADO DA ELEIÇÃO - ATA DA ELEIÇÃO',1,2,NULL),(28,'REALIZAÇÃO DA POSSE - ATA DE POSSE NOVOS MEMBROS',1,2,NULL),(29,'ORGANIZAÇÃO DO CALENDÁRIO REUNIÕES MENSAIS',1,2,NULL),(30,'TÉRMINO DO MANDATO ANTERIOR',2,2,NULL);
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
INSERT INTO `modulo` VALUES (1,'CIPA'),(2,'Comissão Interna de Trabalhadores');
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
INSERT INTO `templates_emails` VALUES (1,'[CIPA] Edital do Processo','<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Edital - CIPA</title>\r\n    <style>\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"body\">\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"alert alert-good\">\r\n                                Edital da CIPA <span style=\"background-color: rgb(255, 0, 0);\">@ANO</span> - Gestão <span style=\"background-color: rgb(255, 0, 0);\">@GESTÃO</span>\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Aos <span style=\"background-color: rgb(255, 255, 0);\">@DATA</span>, <span style=\"background-color: rgb(255, 255, 0);\">@EMPRESA</span>, situada na <span style=\"background-color: rgb(255, 255, 0);\">@ENDEREÇO</span>, nesta cidade de <span style=\"background-color: rgb(255, 255, 0);\">@CIDADE</span>, através de seu SESMT – Serviço Especializado em Engenharia de Segurança e Medicina do Trabalho - informa a todos os associados que na data de hoje tem início o processo de constituição da CIPA – Comissão Interna de Prevenção de Acidentes – de acordo com o item 5.38 da Norma Regulamentadora – 05, aprovada pela Portaria nº3. 214 de 08 de Junho de 1978 com alteração da Portaria SIT n.º 247, de 12 de Julho de 2011.<br>\r\n                                            Todo o processo atenderá ao disposto na legislação citada acima.<br>\r\n                                            As inscrições serão aceitas do dia <span style=\"background-color: rgb(255, 255, 0);\">@INÍCIO INSCRIÇÕES</span> à <span style=\"background-color: rgb(255, 255, 0);\">@FIM INSCRIÇÕES</span>.\r\n                                            <br>\r\n                                            Os interessados deverão acessar o sistema no link <a href=\"link\"><span style=\"background-color: rgb(255, 255, 0);\">@LINK</span></a> para fazer a candidatura.\r\n                                            A eleição – votação será realizada do dia <span style=\"background-color: rgb(255, 255, 0);\">@INÍCIO VOTAÇÃO</span> à <span style=\"background-color: rgb(255, 255, 0);\">@FIM VOTAÇÃO</span>.\r\n                                            <br>\r\n                                            Todos os eventos do processo serão comunicados através de editais fixados em locais de fácil acesso.\r\n                                            <br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RODAPÉ</span>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Sistema de Votação Online</td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n'),(2,'[CIPA] Comunicação ao Sindicato','<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Comunicação: CIPA</title>\r\n    <style>\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"body\">\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"alert alert-good\">\r\n                                Comunicação: CIPA\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Finalidade: Comunicação de eleições para CIPA<br>\r\n                                            Destinatário: <span style=\"background-color: rgb(255, 255, 0);\">@DESTINATÁRIO</span>\r\n                                        </td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Prezado,<br><br>\r\n                                            De acordo com a Norma Regulamentadora - NR 5, aprovada pela Portaria nº 3.214 de 8 de junho de 1978, baixada pelo Ministério do Trabalho, informamos o início do processo eleitoral para representantes dos associados na Comissão Interna de Prevenção de Acidentes – CIPA da {3} situado na {4}, na cidade de {5}, a ser realizada em escrutínio secreto conforme cronograma abaixo:<br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@CRONOGRAMA</span>\r\n                                            <br><br>\r\n                                            Sem mais no momento.\r\n                                            <br><br>\r\n                                            Atenciosamente,\r\n                                            <br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RODAPÉ</span>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Sistema de Votação Online</td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n'),(3,'[CIPA] Inscrições para CIPA','<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Inscrições para CIPA</title>\r\n    <style>\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"body\">\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"alert alert-good\">\r\n                                Edita de Inscrições para Membros da CIPA <span style=\"background-color: rgb(255, 0, 0);\">@ANO</span> – GESTÃO <span style=\"background-color: rgb(255, 0, 0);\">@GESTÃO</span>\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Aos <span style=\"background-color: rgb(255, 255, 0);\">@DATA</span>, o(a) <span style=\"background-color: rgb(255, 255, 0);\">@EPRESA</span>, situado(a) no(a) <span style=\"background-color: rgb(255, 255, 0);\">@ENDEREÇO</span>, nesta cidade de <span style=\"background-color: rgb(255, 255, 0);\">@CIDADE</span>, convida seus associados a realizarem suas inscrições para eleição dos membros representantes dos Empregados da Comissão Interna de Prevenção de Acidentes – CIPA – Gestão {1}, de acordo com o item 5.40, alínea a, b e c, da Norma Regulamentadora – nº 05, aprovada pela Portaria nº 3.214 de 08 de Junho de 1978, com alteração da  Portaria SIT n.º 247, de 12 de julho de 2011.\r\n                                            <br>\r\n                                            AS INSCRIÇÕES PODERÃO SER REALIZADAS A PARTIR DO DIA DE HOJE, <span style=\"background-color: rgb(255, 255, 0);\">@INÍCIO</span> AO DIA <span style=\"background-color: rgb(255, 255, 0);\">@FIM</span>\r\n                                            <br>\r\n                                            Os interessados deverão se cadastrar no link <a href=\"link\"><span style=\"background-color: rgb(255, 255, 0);\">@LINK</span></a>.\r\n                                            <br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RODAPÉ</span></a>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Sistema de Votação Online</td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n'),(4,'[CIPA] Relação de Candidatos','<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Candidatos - CIPA</title>\r\n    <style>\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"body\">\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"alert alert-good\">\r\n                                 Relação de Candidatos Inscritos da CIPA <span style=\"background-color: rgb(255, 0, 0);\">@ANO</span> Gestão <span style=\"background-color: rgb(255, 0, 0);\">@GESTÃO</span>\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Ficam convocados os associados, estagiários e temporários do(a) <span style=\"background-color: rgb(255, 255, 0);\">@EMPRESA</span>, <span style=\"background-color: rgb(255, 255, 0);\">@ENDEREÇO</span>, na cidade de <span style=\"background-color: rgb(255, 255, 0);\">@CIDADE</span>, para a eleição de seus representantes na Comissão Interna de Prevenção de Acidentes - CIPA, de acordo com a Norma Regulamentadora - NR 5, aprovada pela Portaria nº 3.214 de 8 de junho de 1978, baixada pelo Ministério do Trabalho, a ser realizada em escrutínio secreto no dia 25 de abril de 2017.<br>\r\n                                            Apresentaram-se e serão votados os seguintes candidatos:<br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@CANDIDATOS</span>\r\n                                            <br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RODAPÉ</span>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Sistema de Votação Online</td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n'),(5,'[CIPA] Convite para Votação','<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Votação - CIPA</title>\r\n    <style>\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"body\">\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"alert alert-good\">\r\n                                Edital de votação para membros da CIPA <span style=\"background-color: rgb(255, 0, 0);\">@ANO</span> – Gestão <span style=\"background-color: rgb(255, 0, 0);\">@GESTÃO</span>\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Aos {2}, o(a) {3}, situado(a) no(a) {4}, nesta cidade de {0}, através de seu SESMT – Serviço Especializado em Engenharia de Segurança e Medicina do Trabalho - INFORMAMOS A TODOS OS ASSOCIADOS QUE O PROCESSO DE VOTAÇÃO DA CIPA – COMISSÃO INTERNA DE PREVENÇÃO DE ACIDENTES OCORRERÁ DO DIA {5} AO DIA {6}, de acordo com o item 5.38 da Norma Regulamentadora – 05, aprovada pela Portaria nº3. 214 de 08 de Junho de 1978 com alteração da Portaria SIT n.º 247, de 12 de Julho de 2011.<br>\r\n                                            Para a votação, acessar o link <a href=\"http://link\"><span style=\"background-color: rgb(255, 255, 0);\">@LINK</span></a></p>\r\n                                            <br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RODAPÉ</span>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Sistema de Votação Online</td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n'),(6,'[CIPA] Apuração dos Votos','<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n    <title>Apuração de Votos</title>\r\n    <style>\r\n\r\n        .body {\r\n            -webkit-font-smoothing: antialiased;\r\n            -webkit-text-size-adjust: none;\r\n            width: 100% !important;\r\n            height: 100%;\r\n            line-height: 1.6;\r\n            margin: 0;\r\n            padding: 0;\r\n            font-family: \"Helvetica Neue\", \"Helvetica\", Helvetica, Arial, sans-serif;\r\n            box-sizing: border-box;\r\n            font-size: 14px;\r\n        }\r\n\r\n        .body {\r\n            background-color: #f6f6f6;\r\n        }\r\n\r\n        .content-wrap {\r\n            padding: 20px;\r\n        }\r\n\r\n        .body-wrap {\r\n            background-color: #f6f6f6;\r\n            width: 100%;\r\n        }\r\n\r\n        table td {\r\n            vertical-align: top;\r\n        }\r\n\r\n        .content-block {\r\n            padding: 0 0 20px;\r\n        }\r\n\r\n        .container {\r\n            display: block !important;\r\n            max-width: 600px !important;\r\n            margin: 0 auto !important;\r\n            clear: both !important;\r\n        }\r\n\r\n        .content {\r\n            max-width: 600px;\r\n            margin: 0 auto;\r\n            display: block;\r\n            padding: 20px;\r\n        }\r\n\r\n        .main {\r\n            background: #fff;\r\n            border: 1px solid #e9e9e9;\r\n            border-radius: 3px;\r\n        }\r\n\r\n        .alert {\r\n            font-size: 16px;\r\n            color: #fff;\r\n            font-weight: 500;\r\n            padding: 20px;\r\n            text-align: center;\r\n            border-radius: 3px 3px 0 0;\r\n        }\r\n\r\n            .alert.alert-good {\r\n                background: #1ab394;\r\n            }\r\n\r\n        .footer {\r\n            width: 100%;\r\n            clear: both;\r\n            color: #999;\r\n            padding: 20px;\r\n        }\r\n\r\n            .footer p, .footer a, .footer unsubscribe, .footer td {\r\n                font-size: 12px;\r\n            }\r\n\r\n        .aligncenter {\r\n            text-align: center;\r\n        }\r\n    </style>\r\n</head>\r\n\r\n<body class=\"body\">\r\n\r\n    <table class=\"body-wrap\">\r\n        <tr>\r\n            <td></td>\r\n            <td class=\"container\" width=\"600\">\r\n                <div class=\"content\">\r\n                    <table class=\"main\" width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                        <tr>\r\n                            <td class=\"alert alert-good\">\r\n                                Ata de Apuração de Votos CIPA <span style=\"background-color: rgb(255, 0, 0);\">@ANO</span> Gestão <span style=\"background-color: rgb(255, 0, 0);\">@GESTÃO</span>\r\n                            </td>\r\n                        </tr>\r\n                        <tr>\r\n                            <td class=\"content-wrap\">\r\n                                <table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\">\r\n                                    <tr>\r\n                                        <td class=\"content-block\">\r\n                                            Aos <span style=\"background-color: rgb(255, 255, 0);\">@DATA</span>, no(a) <span style=\"background-color: rgb(255, 255, 0);\">@EMPRESA</span>, situado(a) no(a) <span style=\"background-color: rgb(255, 255, 0);\">@ENDEREÇO</span>, na cidade de <span style=\"background-color: rgb(255, 255, 0);\">@CIDADE</span>, diante a apuração ficou constatada a participação superior a cinquenta por cento dos empregados na votação, eximindo-se a empresa de nova votação, de acordo com o item 5.41 da Norma Regulamentadora – 05 aprovada pela Portaria nº 3.214 de 8 de Junho de 1978 com alteração da Portaria SIT n.º 247, de 12 de Julho de 2011.<br>\r\n                                            A apuração dos votos ficou aberta para a participação de qualquer associado interessado e chegou-se ao seguinte resultado:<br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RESULTADO</span>\r\n                                            <br><br>\r\n                                            <span style=\"background-color: rgb(255, 255, 0);\">@RODAPÉ</span>\r\n                                        </td>\r\n                                    </tr>\r\n                                </table>\r\n                            </td>\r\n                        </tr>\r\n                    </table>\r\n                    <div class=\"footer\">\r\n                        <table width=\"100%\">\r\n                            <tr>\r\n                                <td class=\"aligncenter content-block\">Sistema de Votação Online</td>\r\n                            </tr>\r\n                        </table>\r\n                    </div>\r\n                </div>\r\n            </td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n\r\n</body>\r\n</html>\r\n');
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
