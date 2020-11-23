using Microsoft.IdentityModel.Tokens;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.API.Infrastructure
{
    public class TokenService { 

        const string passPhrase = "DGKmaMcG-m9+rc*Evk9Q8ftdU%$xR7ftf92Dv?@t$v_f!?JbU*AACQVjKjGygV2&9h$gpfAte5JK!=$77pdXaRDg2gmnmnXCM5^uGw@pEfc73AD^@Pgq_6=+gU-JpAXt=ktW3qTAAwFf&bSP2MpLrHKdqyuPmbLVH+!7?dM#bhdZ#xjF=DC*n42bH3bmYRw@H%m3FerseXp?UrWARCrUGcPgQt%Uh7?qv*Fkz#Gg&LUat6C=_ZSvDAuGkBtXqsaJRxqpq-!qUsb6W^uQeD&ZRkhp!rw?^rR78MCd#gyp^YKSB+8AZ!*4qeJ%_FcFcEmD_F%ZSZ^^N&X?%36M=UdFhsc_AAjuV*@hKFtLAZ8m*ZwVMp_!mG%yQGekBrJYcUYfXVqhg3x3NYe!ba@ztwyAR6g-byH7W?KB_p?!=7z6tTEtF%64^vSLZS+UtN&k^4WSV7!seg4?QMz$#**mYzACw+E$L7RBL9W+m^V$T=CmWT&!uxyVgH!VMusHg+z4+=Kj7j^YQwdRuyDkcr*&vuZzn&rSHvxhNJ9KnJmK@V5CKGQeCnK89Q2_bHL!5wJJZH-rg22yTj!LCu*zeE-3jfq#aP+L?KbYNngmmekXgrMcG&++%qv8-w^f+VY*U7CZ-_QTSm!GLsqNBemeR^e9=Q&vdBy&53RaZ8c#ddxWvnqs^!2=XH-eZ#ay_!&g6kg#6Z3T%#GtG*Nx@^DcXAym_=_VV9?br%et#n*taV=aN!&&KTAg6jAGZQ6!LL%gcwkbH%xP%RgngCpW5HBKhnnYBrf2Q%Km6cRK@cF^#de%EEADF=Zep?!GvtG-5?S!FYDqKU2k2rhQS&qFEk+LX5hKh9k6pKkKuQufMU2BQ+Ej*^a?4g9T=HUarXW2!F%za8HBYmq2-JgRn7knkPa73!Edz=7Tm+zU*@pf^ATbTXy!8xL@&BM6^mBTVxh-Rys6c7qRa&TqdNz+B2+R=W7W*Gp#NB@ESgD9@ZLw4n$%cV_?xG=aBk5fa*dr5ga4JPx2#R^tpPVzPsejB8SSB4Eq+B7K3E?Yg^?7M=VnaU5Kwhyxp-pZEU9vL!CJ$#U%-=4Ty&M=+BMVWfnY5GK_Jf$Za4X9#S!zme+86j&hA-+yw==5-enj+ZnL4eFgf#tTGe^4uLA7CS_hANb$5^h--Rs7?#qF+*vq9+=PKuPccfXB*7m-MNuEf722e24cuCfXsjR#yFBRwz^uJ4dpzA5Neg_QrB5Y=86+Awu&%ZvFBb+JV_pHev*Mv+ERySfAK!#G6CbM!PJS7!pyD2x-#*ydW97ha4^$4!zU%kWL=@Q2hx5TMd@X?bk3#=_!Wt9n3K*vGgxp_cC^gpq%u2juwq*jYwAs&Z3JxaMQgSEVS!n4gnfMn56WCtRtxZ#H!dXb3cJH^x$5ZHxR$kM5NhJZzWd5WJEu+RXd6ZGP2$qXmyF+ym&^f+KwBHyRP9f%yjTtsG-gt^*NtDdb5LjPDmXKY3MLmmMDCL8TBTRXfx6kr#&RxcRw*PskQ72X6uf$HtehzmK&_fS7cQ4y^Mx-b^w%K2m7n_yUVH*VmBdQn5LDeXed3EsL=PdtkNsxhL+Bx7#7gGvZm5MNy#%yN=8hf3m7UBb+Ld++A=m?$*#^ZT*eP4G5Q@8ZpPbZ*z7u?PMVK&r#WFZFuX@NK%jzfDs3XJjzRJTSzC=s^$PfqX2dMHMFretK_$Ncy^WM$GhUgSHWCBCdR5mQej%KpSf9n9vP%?RdP+TNU7Guj5+9DuCXj^xvnKVfDSyNj*hx8V#3M#k$kpsdXZt&HYPsFG2s3Dt!3bmSAVjPCJ?jsv8-Wu%pt?N7$vgp#TLJG9tEbN$S5bbm!5ca9JT6N9z$k!NJXgt8zLr%?=DyV%u-YvRhryU^BNFp2jTzrkfV+G_qyj#GdeFYbQ!&^Lv*pTrPTLD9_rC4Dfx%MyRW6C37JS#&!8&s6UTgNQYqh7Crny?p@uYLnC-X^ha5Wp+E&FwRZ78p-48%-tYSW=N94TWRD2zFRTQfUh$FbdTxxCmBp_rzu9$^!TM+_2!QWg9rGz6_WLyPa3_=";

        private JwtSecurityTokenHandler _handler;
        private JwtHeader _header;

        public JwtSecurityTokenHandler Handler
        {
            get
            {
                return _handler ??= new JwtSecurityTokenHandler();
            }
        }
        public JwtHeader Header
        {
            get
            {

                if (_header is null)
                {
                    byte[] key = Encoding.UTF8.GetBytes(passPhrase);

                    SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(key);

                    SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

                    _header = new JwtHeader(signingCredentials);
                }

                return _header;

                // =
                //return _header ??= new JwtHeader(
                //    new SigningCredentials(
                //        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(passPhrase)),
                //                                 SecurityAlgorithms.HmacSha256));
            }
        }

        public string GeneratorToken(Customer customer)
        {
            JwtSecurityToken token = new JwtSecurityToken(
                Header,
                new JwtPayload(
                    issuer: "Product Web API",
                    audience: null,
                    claims: new Claim[]
                    {
                            new Claim("CustomerId", customer.id.ToString()),
                            new Claim("FirstName", customer.firstName),
                            new Claim("LastName", customer.lastName)
                    },
                    notBefore: DateTime.Now,
                    expires: DateTime.Now.AddDays(1)
                    )
                );


            return "Bearer " + Handler.WriteToken(token);
        }


        public Customer VerifyToken(string token)
        {
            if (token.StartsWith("Bearer "))
                token = token.Replace("Bearer ", "");

            Customer customer = null;
            JwtSecurityToken securityToken = new JwtSecurityToken(token);

            if (securityToken.ValidFrom <= DateTime.Now && securityToken.ValidTo >= DateTime.Now)
            {
                JwtPayload payload = securityToken.Payload;
                string test = Handler.WriteToken(new JwtSecurityToken(Header, payload));

                if (token == test)
                {
                    payload.TryGetValue("Id", out object id);
                    payload.TryGetValue("FirstName", out object firstName);
                    payload.TryGetValue("LastName", out object lastName);

                    customer = new Customer() { id = int.Parse((string)id), firstName = (string)firstName, lastName = (string)lastName };
                }
            }
            return customer;
        }

    }
    }