package com.teamx.domain;

import javax.persistence.*;

@Entity
public class Olod {
	private int id;
	
	
	private String naam;
	private int studiepunten;
	private String omschrijving;
	
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getNaam() {
		return naam;
	}
	public void setNaam(String naam) {
		this.naam = naam;
	}
	public int getStudiepunten() {
		return studiepunten;
	}
	public void setStudiepunten(int studiepunten) {
		this.studiepunten = studiepunten;
	}
	public String getOmschrijving() {
		return omschrijving;
	}
	public void setOmschrijving(String omschrijving) {
		this.omschrijving = omschrijving;
	}
}
