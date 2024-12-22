package model

import "gorm.io/gorm"

type User struct {
	gorm.Model
	Name string
	Password string
	Email string `gorm:"unique"`
	Phone string `gorm:"unique"`
	Address string
	City string
}

type Product struct {
	gorm.Model
	Name string `gorm:"type:varchar(255);uniqueIndex:user_product_unique"` // composite key
	Avilability uint `gorm:"default:10"`
	Rating float32 `gorm:"default:4"`

	UserId string `gorm:"type:varchar(255);uniqueIndex:user_product_unique"` // composite key

}


