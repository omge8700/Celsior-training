package goconcurrency

import (
	"fmt"
	"time"
)

func cook(dish string,channel char string) {
	fmt.Println("Start Cooking %s ",dish)
	

	// cooking something 

	fmt.Printf("End Cooking %s \n", dish)
	channel <- " I'm Cooking" + dish;
}
func main(){
	
	fmt.Println("Starting the main function")
	//there are 2 subroutines main function and anf cook function
	channel := make(char string)
	go cook("pasta",channel);
	  // if we want to make a function to make concurrent we write go at starting 
	//the channe

	




	fmt.Println("Completing the main function")
}
