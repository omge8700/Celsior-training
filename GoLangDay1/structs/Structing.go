package structs

import "fmt"

type Person struct {
	FirstName string
    LastName  string
	Email string
	Age uint
}
func NewPerson(firstName string,
lastName  string,
Email     string,
Age       uint) Person{
	return Person{
		firstName : fir
	}
	
}

//Reciever function
func (person Person) GetFirstName()string{
	return person.firstName
}
func (person Person) SetFristName(updatedName string){
	person.FirstName = updatedName
}

func Structs() {
	rahul := Person{FirstName: "Rahul", LastName: "Chhabra", Email: "chhabra@gmail.com", Age: 23};
	john := Person{FirstName: "John", LastName: "Doe", Email: "chhabra@gmail.com", Age: 23};

	person1 = NewPerson("stetve","kinney",56);
	fmt.Println(rahul.FirstName)
	fmt.Println(john.FirstName)
}