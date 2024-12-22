package jwt

import (
	"auth-micro/model"
	"fmt"
	"time"

	//"fmt"
	"net/http"
	"os"
	"strings"

	"github.com/dgrijalva/jwt-go"
	"github.com/gin-gonic/gin"

)

type JWTManager struct {
	secretkey     string
	tokenDuration time.Duration
}

type UserClaims struct{
	jwt.StandardClaims
	UserEmail string
	

}
//Responsiblity is create a new JWT manager
func NewJWTManager(secretkey string ,tokenDuration time.Duration )(*JWTManager){
	return &JWTManager{
		secretkey : secretkey,
		tokenDuration: tokenDuration,
	}
}


func (jwtmanager * JWTManager) GenratingToken(user *model.User) (string ,error) {
		//1 preparing the user claims --user claims contain all the info of user model
		claims := UserClaims{
				StandardClaims: jwt.StandardClaims{
					ExpiresAt : time.Now().Add(jwtmanager.tokenDuration).Unix(),
				},
				UserEmail: user.Email,

		}
		//create token
		token := jwt.NewWithClaims(jwt.SigningMethodHS256,claims);

		return token.SignedString([]byte (jwtmanager.secretkey))	
}

// ? Responsibility :- decode the token and get the userClaims and return the userEmail. (userClaims/userEmail);

func VerifyToken(accessToken string) ( *UserClaims,error) {
	token,err := jwt.ParseWithClaims(
		accessToken,
		&UserClaims{},
		func (token *jwt.Token) (interface{},error) {
			_,ok := token.Method.(*jwt.SigningMethodHMAC);

			if !ok {
				return nil,fmt.Errorf("Unexpected Token signing Method")
			}

			return [] byte(os.Getenv("SECRET_KEY")),nil;
		},


	);
	if err != nil {
		return nil,fmt.Errorf("Invalid Token %w",err);

	}
	claims, ok := token.Claims.(*UserClaims);
	if !ok {
		return nil, fmt.Errorf("Invalid Token %w", err);	
	}
	return claims, nil
};

func AuthorizeJwtToken() gin.HandlerFunc {
	return func (ctx *gin.Context) {
		tokenString := ctx.GetHeader("Authorization");
		if len(tokenString) == 0 {
			ctx.JSON(http.StatusUnauthorized,gin.H{"jwt failure":"Authorization token is not provided."})
			ctx.Abort();
		}

		token := strings.Split(tokenString," ")[1];
		claims,err := VerifyToken(token);

		if err != nil {
			ctx.JSON(http.StatusUnauthorized,gin.H{"jwt failure":"Authorization token is not provided."})
			ctx.Abort();
		}
		ctx.Set("usermail", claims.UserEmail);
		ctx.Next();
	}
}







