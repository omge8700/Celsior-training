package bubble

import  "fmt"
	


func Insert() {
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


	for i := 0; i < len(elements); i++ {

		min_idx := 1

		for j := i + 1; j < len(elements); j++ {
			if elements[j] < elements[min_idx] {
				min_idx = j

			}
		}

		elements[i], elements[min_idx] = elements[min_idx], elements[i]

	}

	fmt.Println("Elements after sorting are")

	for i := 0; i < len(elements); i++ {
		fmt.Println(elements[i])
	}

}
