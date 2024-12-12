package bank
 
import (
	"fmt"
	"time"
)
 
func showMenu() {
	fmt.Println("\n--- Bank Menu ---")
	fmt.Println("1. Deposit Amount")
	fmt.Println("2. Cash Withdrawal")
	fmt.Println("3. Check Balance")
	fmt.Println("4. Transaction History")
	fmt.Println("0. Exit")
	fmt.Print("Enter your choice: ")
}
 
var bankAccount float64
var transactionHistory []string
 
func depositAmount() {
	var amount float64
	fmt.Print("Enter the amount to deposit: ")
	fmt.Scanln(&amount)
	if amount > 0 {
		bankAccount += amount
		timestamp := time.Now().Format("2006-01-02 15:04:05")
		transactionHistory = append(transactionHistory, fmt.Sprintf("[%s] Deposited: %.2f", timestamp, amount))
		fmt.Printf("Successfully deposited %.2f\n", amount)
	} else {
		fmt.Println("Deposit amount must be positive!")
	}
}
 
func withdrawAmount() {
	var amount float64
	fmt.Print("Enter the amount to withdraw: ")
	fmt.Scanln(&amount)
	if amount > 0 && amount <= bankAccount {
		bankAccount -= amount
		timestamp := time.Now().Format("2006-01-02 15:04:05")
		transactionHistory = append(transactionHistory, fmt.Sprintf("[%s] Withdrawn: %.2f", timestamp, amount))
		fmt.Printf("Successfully withdrawn %.2f\n", amount)
	} else if amount > bankAccount {
		fmt.Println("Insufficient funds!")
	} else {
		fmt.Println("Withdrawal amount must be positive!")
	}
}
 
func checkBalance() {
	fmt.Printf("Your current balance is: %.2f\n", bankAccount)
}
 
func showTransactionHistory() {
	if len(transactionHistory) == 0 {
		fmt.Println("No transaction history available.")
	} else {
		fmt.Println("\nTransaction History:")
		for i, record := range transactionHistory {
			fmt.Printf("%d. %s\n", i+1, record)
		}
	}
}
 

