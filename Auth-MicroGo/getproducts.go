package main

import (
	"auth-micro/model"
	"fmt"
	"net/http"

	"github.com/gin-gonic/gin"
)

func GetAllTheProducts(ctx *gin.Context) {
	logger.Info("Recieved Get All Products Request")
	userEmail := ctx.GetString("usermail");
	if userEmail == "" {
		logger.Error("failed to get the token from the header")
		ctx.JSON(http.StatusInternalServerError, gin.H{"message":"failed to get the token from the header"})
		return
	}
	// get the userId.
	var user model.User
	userDbConnector.Where("email = ?", userEmail).First(&user);

	fmt.Println(user.ID);
	var products []model.Product

	err := productDbConnector.Where("user_id = ?", user.ID).Find(&products);

	if err.Error != nil {
		logger.Error("Failed to get the products")
		ctx.JSON(http.StatusInternalServerError, gin.H{"message":"Failed to get the products from the db"})
		return;
	}
	logger.Info("Hurray! we got the products");
	ctx.JSON(http.StatusOK, gin.H{"products":products});
}