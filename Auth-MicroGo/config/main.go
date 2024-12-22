package config

import (
	"auth-micro/model"
	"fmt"
	"log"
	"os"
	//"strings"

	"golang.org/x/crypto/bcrypt"
	"gorm.io/driver/mysql"
	"gorm.io/gorm"
)

func DatabaseDsn() string {
	return fmt.Sprintf("%s:%s@tcp(%s:%s)/%s?charset=utf8&parseTime=True&loc=Local",
		os.Getenv("MYSQL_USER"),
		os.Getenv("MYSQL_PASSWORD"),
		os.Getenv("MYSQL_HOST"),
		os.Getenv("MYSQL_PORT"),
		os.Getenv("MYSQL_DATABASE"),
	)
}

func GenerateHashedPassword(password string) string {
	hashedPassword, err := bcrypt.GenerateFromPassword([]byte(password), bcrypt.DefaultCost)
	if err != nil {
		log.Fatalf("Couldn't hash password and the error is %s", err)
	}
	return string(hashedPassword)
}
func ComparePassword(hashedPassword string, password string) error {
	return bcrypt.CompareHashAndPassword([]byte(hashedPassword), []byte(password))
}

func ConnectDB()( *gorm.DB ,  *gorm.DB) {
	userdb, err := gorm.Open(mysql.Open(DatabaseDsn()), &gorm.Config{})

	if err != nil {
		panic("Failed to connect DB")
	}
	userdb.AutoMigrate(&model.User{});
	productdb,err := gorm.Open(mysql.Open(DatabaseDsn()), &gorm.Config{});

	if err != nil {
		panic("Failed to connect DB");
	}
	productdb.AutoMigrate(&model.Product{});
	return userdb,productdb
}
// func ValidatePhone(phone string) bool {
// 	if len(phone) != 10 {
// 		return false
// 	}
// 	for _, digit := range phone {
// 		if digit < '0' && digit > '9' {
// 			return false
// 		}
// 	}
// 	return true
// }
// func ValidatingFieldsOfUser(user model.User) bool {
// 	fmt.Println(user)
// 	if user.Name != "" || user.Password != "" || user.Address != "" || user.City != "" {
// 		return false
// 	}
// 	if !strings.Contains(user.Email, "@") || !strings.Contains(user.Email, ".") {
// 		return false
// 	}
// 	return len(user.Password) >= 6 && ValidatePhone(user.Phone)
// }
