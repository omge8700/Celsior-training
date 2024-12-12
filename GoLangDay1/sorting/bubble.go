package bubble

import  "fmt"
	


func Bubblesort() {

	var size int
	fmt.Printf("Enter the size f array :")
	fmt.Scanln(&size)

	elements := make([]int, 0, size)

	for i := 0; i < size; i++ {
		var value int
		println("Enter the values")
		fmt.Scanln(&value)
		elements = append(elements, value)

	}

	

	for j := 0; j < len(elements); j++ {
		flag := false
		for k := 0; k < len(elements)-j-1; k++ {
			if elements[k] > elements[k+1] {
				elements[k], elements[k+1] = elements[k+1], elements[k]

				flag = true

			}

		}
		if !flag {
			break
		}

	}

	fmt.Println("Elements after sorting  are")
	for i := 0; i < len(elements); i++ {
		fmt.Println(elements[i])
	}

}
