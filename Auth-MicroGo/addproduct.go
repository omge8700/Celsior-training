package main

import (
	"auth-micro/model"
	"fmt"
	"net/http"
	"strconv"

	"github.com/gin-gonic/gin"
	"go.uber.org/zap"
)

func AddProduct(ctx *gin.Context) {

	logger.Info("Recieved Add Product Request")
	var product model.Product
	ctx.ShouldBindJSON(&product)

	userEmail := ctx.GetString("usermail");
	fmt.Println(userEmail)
	if userEmail == "" {
		logger.Error("failed to get the token from the header")
		ctx.JSON(http.StatusInternalServerError, gin.H{"message": "failed to get the token from the header"})
		return
	}

	if product.Name == "" {
		ctx.JSON(http.StatusBadRequest, gin.H{"message": "Name field is missing, please add the name field"})
		return
	}

	//get the userid

	var user model.User
	userDbConnector.Where("email = ?", userEmail).First(&user)

	//? adding the user id inside the product...
	product.UserId = strconv.FormatUint(uint64(user.ID), 10)

	// ? check for the existing product
	var existingProduct model.Product
	productErrorNotFound := productDbConnector.Where("name = ? AND user_id = ?", product.Name, product.UserId).First(&existingProduct).Error

	if productErrorNotFound == nil {
		ctx.JSON(http.StatusConflict, gin.H{"message": "Same Product Already Exist."})
		ctx.JSON(http.StatusConflict, gin.H{"message": "Same Product Already Exist."})
		return
	}

	primaryKey := productDbConnector.Create(&product)
	if primaryKey.Error != nil {
		logger.Error("Failed to add sthe product")
		ctx.JSON(http.StatusInternalServerError, gin.H{"message": "Failed to add sthe product"})
		return
	}
	logger.Info("Product Added Successfully!", zap.String("ProductId", strconv.FormatUint(uint64(product.ID), 10)))
	ctx.JSON(http.StatusCreated, gin.H{"message": "Product Added Successfully!"})

}
