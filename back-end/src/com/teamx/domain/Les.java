package com.teamx.domain;

import java.util.Calendar;

public class Les {
	private int id;
	private Calendar tijdstip;
	private Olod olod;
	private int duur; // In minuten
	private String lokaal;
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public Calendar getTijdstip() {
		return tijdstip;
	}
	public void setTijdstip(Calendar tijdstip) {
		this.tijdstip = tijdstip;
	}
	public Olod getOlod() {
		return olod;
	}
	public void setOlod(Olod olod) {
		this.olod = olod;
	}
	public int getDuur() {
		return duur;
	}
	public void setDuur(int duur) {
		this.duur = duur;
	}
	public String getLokaal() {
		return lokaal;
	}
	public void setLokaal(String lokaal) {
		this.lokaal = lokaal;
	}
	
}
