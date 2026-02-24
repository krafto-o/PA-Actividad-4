import tkinter as tk
from tkinter import messagebox
import re

# Funciones de Validación
def EnteroValido(valor):
    try:
        int(valor)
        return True
    except ValueError:
        return False

def DecimalValido(valor):
    try:
        float(valor)
        return True
    except ValueError:
        return False

def TelefonoValido(valor):
    # Verifica que sean solo dígitos y tenga longitud de 10
    return valor.isdigit() and len(valor) == 10

def TextoValido(valor):
    # Verifica que solo contenga letras y espacios
    return bool(re.match("^[a-zA-Z\\s]+$", valor))

def borrar():
    tbNombre.delete(0, tk.END)
    tbApellidos.delete(0, tk.END)
    tbEdad.delete(0, tk.END)
    tbTelefono.delete(0, tk.END)
    tbEstatura.delete(0, tk.END)
    rbSeleccionGenero.set(0)

def guardar():
    nombres = tbNombre.get()
    apellidos = tbApellidos.get()
    edad = tbEdad.get()
    tel = tbTelefono.get()
    estatura = tbEstatura.get()
    
    genero = ""
    if rbSeleccionGenero.get() == 1:
        genero = "Masculino"
    elif rbSeleccionGenero.get() == 2:
        genero = "Femenino"
    elif rbSeleccionGenero.get() == 3:
        genero = "No Definido"

    # Verificación de todas las validaciones antes de guardar
    if (EnteroValido(edad) and DecimalValido(estatura) and 
        TelefonoValido(tel) and TextoValido(nombres) and 
        TextoValido(apellidos)):
        
        datos = (f"Nombre: {nombres}\nApellidos: {apellidos}\n"
                 f"Edad: {edad}\nTelefono: {tel}\n"
                 f"Estatura: {estatura}\nGenero: {genero}")
        
        with open("Datos3N_13Feb26.txt", "a") as archivo:
            archivo.write(datos + "\n\n")
            
        messagebox.showinfo("Informacion", "Datos guardados correctamente\n\n" + datos)
    else:
        messagebox.showerror("Error", "Algunos de los campos tienen formato equivocado")

# Interfaz Gráfica
ventana = tk.Tk()
ventana.configure(bg="#9dceea")
ventana.geometry("350x600")
ventana.title("Actividad 04 Formulario de Registro Vr. 002")

rbSeleccionGenero = tk.IntVar()

# Elementos de la interfaz
tk.Label(ventana, text="Nombre:", font=("Jet Brains Mono Nerd", 12, "bold"), bg="#9dceea").pack(pady=5)
tbNombre = tk.Entry(ventana, width=35, justify="center")
tbNombre.pack()

tk.Label(ventana, text="Apellidos:", font=("Jet Brains Mono Nerd", 12, "bold"), bg="#9dceea").pack(pady=5)
tbApellidos = tk.Entry(ventana, width=35, justify="center")
tbApellidos.pack()

tk.Label(ventana, text="Edad:", font=("Jet Brains Mono Nerd", 12, "bold"), bg="#9dceea").pack(pady=5)
tbEdad = tk.Entry(ventana, width=10, justify="center")
tbEdad.pack()

tk.Label(ventana, text="Estatura:", font=("Jet Brains Mono Nerd", 12, "bold"), bg="#9dceea").pack(pady=5)
tbEstatura = tk.Entry(ventana, width=15, justify="center")
tbEstatura.pack()

tk.Label(ventana, text="Telefono:", font=("Jet Brains Mono Nerd", 12, "bold"), bg="#9dceea").pack(pady=5)
tbTelefono = tk.Entry(ventana, width=35, justify="center")
tbTelefono.pack()

# Grupo Género
gb = tk.LabelFrame(ventana, text="Seleccione un Genero", padx=10, pady=8, bg="#9dceea")
gb.pack(pady=15)
tk.Radiobutton(gb, text="Masculino", value=1, variable=rbSeleccionGenero, bg="#9dceea").grid(row=0, column=0)
tk.Radiobutton(gb, text="Femenino", value=2, variable=rbSeleccionGenero, bg="#9dceea").grid(row=0, column=1)
tk.Radiobutton(gb, text="No Definido", value=3, variable=rbSeleccionGenero, bg="#9dceea").grid(row=0, column=2)

# Botones
btnGuardar = tk.Button(ventana, text="Guardar", width=15, command=guardar)
btnGuardar.pack(pady=5)
btnBorrar = tk.Button(ventana, text="Borrar", width=15, command=borrar)
btnBorrar.pack(pady=5)

ventana.mainloop()
