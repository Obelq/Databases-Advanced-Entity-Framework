﻿ALTER TABLE [Customers] ADD [Age] [int] NOT NULL DEFAULT 20
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201703081250163_AddDefaultValueOnAgeInCustomers', N'SalesDatabase.SalesContext',  0x1F8B0800000000000400ED5BC96EE43610BD07C83F083A2581A7657B2E13A37B06931E3B68C45BDCF620378396D86D2212A59094D146902FCB219F945F08A995E2A2A5377B82812F6A8A55ACE5B18A2C95FFFDFB9FF18755143A4F905014E3897B343A741D88FD384078397153B678F3CEFDF0FEDB6FC6A741B4723E97F3DE8A799C12D389FBC85872E279D47F8411A0A308F924A6F1828DFC38F240107BC787873F7A47471EE42C5CCECB71C63729662882D90FFE731A631F262C05E1451CC09016E3FCCD3CE3EA5C8208D204F870E2CE4108E927C0C003A0D0753E86087021E6305CB80EC038668071114FEE289C3312E3E53CE10320BC7D4E209FB700A1A0CA443FA9A7F7D5E2F05868E1D584252B3FA52C8E06323C7A5B98C553C9D732AE5B998D1BEE941B983D0BAD33E34DDC69B60424AEA32E76320D8998A8D87694FB6254121E388DD707151A3868C4DF81334D43961238C13065048407CE75FA1022FF17F87C1BFF0EF104A761280BC9C5E4EF1A037CE89AC40924ECF9062E0AD16781EB784D3A4F25ACC8249A5CA919666F8F5DE7922F0E1E4258614032C09CC504FE0C312480C1E01A300609163C6066456D7565AD334428138FE5921C797CFFB8CE05589D43BC648F13973FBACE195AC1A01C29C4B8C3886F374EC4480A0D62B62F7D0E5E6AE5D308A0700BCBB6AF322530406C0A487099460F02BDDB5EF0123CA165060365E90CED6731A937CE0D0CB389F4112579C8198949F7F58C33124737715850572FEE6F015942C6858F4D6FE7714A7C45B2B157EFE0D67D2D580DDED362F0EB7EB6ADC54D526D28F17C8BA21EFBC30AA46D00A88488194025BCFA4AC47F06A9CF8C0215EFEE33705C2DAAA9B564E6191AC62DD34C606FDD86C297E7B15FE4459309E519F972339C0D36EC699DA5EF4EFBD48DB66A65CB81BBB5A0FBBA616D6BBD4C06FC3505857445A888B9B587B3B926C8AFC30DF45104785EBD26FCA93894BF739DB90F044393193B6219A43E4149BE79F69B3BA5E0B1CD38A386C28E70B45E526D069DA1D955A6FEBA6B6D6B9516DAD3EE6D076B9531769160B4ECDD9D8BFAC0F623A5B18F3226922AF569A2A9FF290E9CD6A345EE80F250C27DC07189128E44BEF4C4FD4133A88D61954E6B86F501A7C9F470343A527595B46A57D612416C427685935ADA2A167509DB87BFC11A3DCC3BC00C2DE8B4FAAB075425719BC1709051FA9CBAB663987C8B4C63CC00E21149DEDB6210AE4CE7AE3B0A8B504E8B30A22A2298CE21538EF2D475EA2DA9615CB346934926938141AE7D0771012B137D05DBAEF5659F1805693A5C6127D9BFA993748D91E618EF396AF2EA8A4D950A95F5BCBE2C4A98492C242FAAF9B1A95C0FC56DC718DD027DC2D5908025295483A2C52C1DF1A9CBC46BD8A62D6F1A10D2338E0D8D64B2620AF2DB40D41DB836B05899D1AB705557BCBDBCE45D96C63D4B6D7C7C0192841F95A45A7931E2CCF342F9F4CD7C781939CA79783E3554932B69AB95B83DC0122A6FF9D25CD2AC285AD7E9A741A44D6B04674BCC2A9752E3AFEEB932889514E2590AB8D521DD16846A0B9E71A5227E86CDF48386C0A193669F2A400888E13C3D8DC334C2B633791BB55458969948C3FD79D5956299553DDA9F5351F995D91443FD79E8755D999DFE56E73CF6146FA988F0344828BB53C5582F04E63B7D7DF465497E38F2CC64BB415D5EFE94E9F39157E3832ADDADEF064BF6EDE1092BE56E9CA16FD9A1DBB52E53C95CEAD1FE9C8A4A95CCA6181A002EB91ED5C098FCE2D5404D39316CB0EF1B67EA3502403BFD6EC0D7ACD034F246E3CDFEDDD53C59E9215ABA8BB44562695A9F882BCE8786E29176D9D0CDD1CB39151B93978445AAC587CA559C85D7946BB038FC4CC7F3B72851CCA828CB5525B99EDAAA27E7C110B0DDCA3AD281367F4D50B4DFDCD6F442C9650BE068BF0ABE2A94D8B5DE18246DD7D35E615CA1593782745E61D7744893F136624AE79DF85541A74BFF6E0069D774754A95E6AAEBBA722D1F1757E4EEBE36EDCE9C4F115F02E3271464F7E567CA6034121346F33FC269887862AD275C008C1690B2FCAB917B7C7874ACF4C7BD9E5E358FD2203494184C0D6B7BFFF4857019FADB3E6E0DFC10AB3589E12740FC4740BE8BC0EAFB8D1BBF36E3D668E6B2B2DAA4616B00D361AD4FFF0F74C82D47017F66BD5A8E2C8D46F78AB0DA678F190EE06AE2FE99D19D38B3DFEE25D203E78AF06872E21C3A7F0DF5BE9CAD870950536EB2BE1EF28749A1D2F797657013D0FF03B7DB0B416A37CD228C01DBAC9926D84333CD4EE29AFDAEFFC502C5D4EC310430DBEE8168D60706B729681F1CD7E89FE0FE8244981384FC804919E1474CAD4EC2018D7D948050955B3F6AF7C1813064C5527DF30926100B07CB7AF559A7A37051F15520D965809DF7826CA1EB639FBEB717AD5FCEF5ED55893D787ED3F697EDB5BAEC11095DD5E497C3439FA2C3D65161EEFDD1BF425B4AFE5A9F7E4B6F4F7E2BE7678B87983B3B4F57F67E1253EB8FB5F3C7C4DADC5860690A6AEB093231B7B58DB4770C75370C1915696DBDD8715391EAD9E6C7FCAE5E22ADD3E38B681B323508BD88AAFBEE02B277FCEC54FD012D3D7A4D90C73EE93F6279F4A56859B310E54E0CFD46D4ABE6CCF0222EC3B022513945398A5F4006021E123F128616C067FCB50F29CDFAAE3F8330CDEA410F3098E1AB942529E32AC3E8216C7C2A1641BC6DFDAC6FA929F3F82ABB38D16DA8C0C544A24C72857F4A511854729F192E0E1616223B14F71BE14B26EE39CBE78AD3658C7B322ACC5725B55B1825216746AFF01C3CC17564BBA3F01C2E81FF5C9676ED4CBA1DD134FBF813024B02225AF0A8E9F94F8EE1205ABDFF0FF9F003C7183E0000 , N'6.1.3-40302')