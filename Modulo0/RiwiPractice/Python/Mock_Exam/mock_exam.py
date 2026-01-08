"""Gestión de inventario de una libreria """
inventory = [
    {"title": "book 1", "price": 10.0, "quantity": 100},
    {"title": "book 2", "price": 15.0, "quantity": 50},
    {"title": "book 3", "price": 20.0, "quantity": 30},
    {"title": "book 4", "price": 25.0, "quantity": 10},
    {"title": "book 5", "price": 30.0, "quantity": 5}
]

def validate_price():#Funcion para verificar que el precio sea correcto
    while True:
        price = input("Enter the price of the product: ")
        if not price:
            print("The field cannot be empty. Please enter a number.")
            continue
        try:
            price = float(price)
            if price > 0:
                return price
            else:
                print("You must enter a positive number.")
        except ValueError:
            print("ERROR! You are entering invalid data. Please enter a valid number.")

def validate_quantity():#Funcion para verificar que la cantidad sea correcta
    while True:
        quantity = input("Enter the quantity of the product: ")
        if not quantity:
            print("The field cannot be empty. Please enter a number.")
            continue
        try:
            quantity = int(quantity)
            if quantity > 0:
                return quantity
            else:
                print("You must enter a positive number.")
        except ValueError:
            print("ERROR! You are entering invalid data. Please enter a valid number.")

def add_book():#Funcion para agregar un nuevo libro
    while True:
        try:    
            title = input("Enter name book: ").strip().lower()
            if not title:
                print("¡ERROR! This space cannot be empty.")
                continue
            #for i in inventory: """CORREGIR Y VALIDAD ENTRADA DE UN DATO YA GUARDADO"""
            #if i in inventory == title:
            #       continue
            price = validate_price()
            quantity = validate_quantity()
            
            new_book = {"title": title, "price": price, "quantity": quantity } 
            inventory.append(new_book)  
            print("\n--- - ---")   
            print(f"the book {title} It was added successfully.")      
            break
        except ValueError:
            print("")

def update_book():#Funcion para actualizar la informacion de un libro
    while True:
        try:
            update_to_book = input("Enter the name of the book you want to update: ").strip().lower()
            if not update_to_book:
                print("¡ERROR! This space cannot be empty.")
                continue
            for i in inventory:
                if i["title"] == update_to_book:
                    new_price = validate_price()
                    new_quantity = validate_quantity()
                    i["price"] = new_price
                    i["quantity"] = new_quantity
                    print("\n--- - ---")
                    print(f"the book {update_to_book} updated successfully")
                    return
        except ValueError:
            print(f"book {update_to_book} not found in inventory.")
            
def consult_book():#Funcion para consultar un libro
    while True:
        search_book = input("Enter the name of the book you want to consult: ").strip().lower()
        for i in inventory:
            if i["title"] == search_book:
                print("\n--- - ---")
                print(f"\nthe book {search_book} was found")
                print(f"--{i}--")
                return
            
def delete_book():#Funcion para eliminar un libro
    while True:
        delete_to_book = input("Enter name book to delete: ")
        if not delete_book:
            print("¡ERROR! This space cannot be empty.")
            continue
        for i in inventory:
            if i["title"] == delete_to_book:
                inventory.remove(i)
                print("\n--- - ---")
                print(f"the book {delete_to_book} delete successfully")
                return
        print(f"book {delete_to_book} not found in inventory.")

def calculate_inventory_value():#Funcion para calcular el valor total de el inventario
    while True: #"""VERIFICAR FUNCIONALIDAD"""
        for i in inventory:
            calculate_inventory = []
            if i["price"] > 0:
                calculate_inventory = [{i["price"],}]
            sum_inventory = sum.calculate_inventory
            count_inventory = len.calculate_inventory
            inventory_value = sum_inventory / count_inventory
            print("\n--- - ---")
            print(f"The value of the inventory is {inventory_value}")
            return
        
def view_inventory():
    print("\n--- - ---")
    print("=====The Inventory Books=====")
    for (i) in inventory:
        print(i)
        
def main():
    while True:
        print("\n--- - ---")
        print(f"\nInventory Options Menu")
        print("1. Add book")
        print("2. Query book")
        print("3. Update book")
        print("4. Delete book")
        print("5. Calculate Total Inventory Value")
        print("6. View inventory")
        print("0. Exit")
        print("\n--- - ---")
        option = input("Select an option: ")
        
        if option == "1":
            print("\n--- - ---")
            add_book()
        elif option == "2":
            print("\n--- - ---")
            consult_book()
        elif option == "3":
            print("\n--- - ---")
            update_book()
        elif option == "4":
            print("\n--- - ---")
            delete_book()
        elif option == "5":
            print("\n--- - ---")
            calculate_inventory_value()
        elif option == "6":
            print("\n--- - ---")
            view_inventory()
        elif option == "0":
            print("\n--- EXIT ---")
            break
        else:
            print("\n--- - ---")
            print("Invalid option, please try again.")

            
# Llamar a la función del menú para iniciar el programa
main()