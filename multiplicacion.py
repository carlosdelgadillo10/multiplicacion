from fastapi import FastAPI
from pydantic import BaseModel


app = FastAPI()

class Operacion(BaseModel):
    num1: float
    num2: float

@app.post("/multiplicar")
def multiplicar(op: Operacion):
    return op.num1 * op.num2